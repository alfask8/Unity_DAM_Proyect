using UnityEngine;
using UnityEngine.Audio;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource audiosource;
    public AudioClip playerSound, brickSound, yellowBrickSound, RedBrickSound, BlueBrickSound, GreenBrickSound, wall, DeathWall;

    [SerializeField] public float speed = 300;
    [SerializeField] float hitOffset = 0.2f;

    private Vector2 velocity;
    private Vector3 initialPosition;

    private bool hasBeenLaunched = false;

    private Player playerScript;
    private Transform playerTransform;

    private void Start()
    {
        initialPosition = new Vector3(0, -4, 0);
        ResetBall();
        playerScript = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasBeenLaunched)
        {
            LaunchBall();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ResetLaunch();
        }

        if (!hasBeenLaunched && playerTransform != null)
        {
            rb.position = new Vector2(playerTransform.position.x, rb.position.y);
        }
    }

    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        rb.position = initialPosition;
        hasBeenLaunched = false;
    }

    void LaunchBall()
    {
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;
        rb.AddForce(velocity * speed);
        hasBeenLaunched = true;
    }

    public void AttachToPaddle(Transform paddleTransform)
    {
        playerTransform = paddleTransform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathWall"))
        {
            FindObjectOfType<GameManager>().LostLives();
            ResetBall();
            audiosource.clip = DeathWall;
            audiosource.Play();
        }
        if (playerScript != null)
        {
            playerScript.ResetPaddleSize();
        }
    }

    public bool HasBeenLaunched()
    {
        return hasBeenLaunched;
    }

    public void ResetLaunch()
    {
        hasBeenLaunched = false;
        rb.velocity = Vector2.zero;
        rb.position = initialPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];

        if (collision.gameObject.GetComponent<Player>())
        {
            audiosource.clip = playerSound;
            audiosource.Play();

            Vector2 paddleCenter = collision.transform.position;
            float hitPointX = contact.point.x;

            if ((rb.velocity.x < 0 && hitPointX > paddleCenter.x + hitOffset) || (rb.velocity.x > 0 && hitPointX < paddleCenter.x - hitOffset))
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            audiosource.clip = brickSound;
            audiosource.Play();
        }
        if (collision.gameObject.CompareTag("BlueBrick"))
        {
            audiosource.clip = BlueBrickSound;
            audiosource.Play();
        }
        if (collision.gameObject.CompareTag("RedBrick"))
        {
            audiosource.clip = RedBrickSound;
            audiosource.Play();
        }
        if (collision.gameObject.CompareTag("GreenBrick"))
        {
            audiosource.clip = GreenBrickSound;
            audiosource.Play();
        }
        if (collision.gameObject.CompareTag("YellowBrick"))
        {
            audiosource.clip = yellowBrickSound;
            audiosource.Play();
        }
        if (collision.gameObject.CompareTag("LeftWall") || collision.gameObject.CompareTag("RightWall") || collision.gameObject.CompareTag("TopWall"))
        {
            audiosource.clip = wall;
            audiosource.Play();
        }
    }
}
