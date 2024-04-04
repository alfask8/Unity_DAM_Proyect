using UnityEngine;

public class YellowBrick : MonoBehaviour
{
    public GameObject playerMinPrefab; // El prefab del objeto "PlayerMin" que se creará

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<GameManager>().levelcomplete();
            DestroyYellowBrick();
            CreatePlayerMin();
        }
    }

    private void DestroyYellowBrick()
    {
        // Aquí puedes añadir efectos visuales o sonidos si lo deseas
        Destroy(gameObject);
    }

    private void CreatePlayerMin()
    {
        Instantiate(playerMinPrefab, transform.position, Quaternion.identity);
    }
}
