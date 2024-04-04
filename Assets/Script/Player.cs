using UnityEngine;

public class Player : MonoBehaviour
{
   
    private float paddleInitialY;
    [SerializeField] float minX = -1.43f;
    [SerializeField]float  maxX = 1.5f;
    private Camera mainCamera;
    private Ball ball;

    private void Start()
    {
        paddleInitialY = this.transform.position.y;
        mainCamera = Camera.main;
        ball = FindObjectOfType<Ball>();
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void Update()
    {
        PaddleMovement();

        if (!ball.HasBeenLaunched())
        {
            ball.AttachToPaddle(this.transform);
        }
    }

    private void PaddleMovement()
    {
        // Obtiene la posición del mouse en el eje X
        float mousePositionPixels = Input.mousePosition.x;

        // Convierte la posición del mouse a coordenadas del mundo en el eje X
        float mousePositionWorldX = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionPixels, 0, 0)).x;

        // Limita la posición de la pala dentro del rango especificado
        float clampedXPosition = Mathf.Clamp(mousePositionWorldX, minX, maxX);

        // Actualiza la posición de la pala
        this.transform.position = new Vector3(clampedXPosition, paddleInitialY, 0);
    }



    private int reductionCount = 0; // Contador para el número de reducciones aplicadas

    public void ShrinkPaddle()
    {


        // Ajustar dinámicamente el rango de movimiento según el número de reducciones aplicadas
        switch (reductionCount)
        {
            case 0:
                transform.localScale = new Vector3(0.8f,1,1);
                minX = -1.63f;
                maxX = 1.68f;
                break;
            case 1:
                transform.localScale = new Vector3(0.6f, 1, 1);
                minX = -1.8f;
                maxX = 1.85f;
                break;
            case 2:
                transform.localScale = new Vector3(0.4f, 1, 1);
                minX = -2.01f;
                maxX = 2.05f;
                break;
            case 3:
                transform.localScale = new Vector3(0.2f, 1, 1);
                minX = -2.21f;
                maxX = 2.23f;
                break;
            case 4:
                transform.localScale = new Vector3(0.1f, 1, 1);
                minX = -2.3f;
                maxX = 2.3f;
                break;
            case 5:
                transform.localScale = new Vector3(0f, 1, 1);
                minX = -2.01f;
                maxX = 2.05f;
                break;
            default:
                reductionCount = 0;
                break;

        }

        reductionCount++; // Incrementar el contador de reducciones

        Debug.Log($"Tamaño de la pala reducido, minX ajustado a {minX}, maxX ajustado a {maxX}.");
    }

    public void ResetPaddleSize()
    {
        // Restablecer el tamaño original de la pala
        Vector3 originalScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        transform.localScale = originalScale;

        // Restablecer el rango de movimiento original
        minX = -1.43f;
        maxX = 1.41f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerMin"))
        {
            ShrinkPaddle();
            Destroy(other.gameObject);
        } 
    }
}
