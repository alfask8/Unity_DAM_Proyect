using UnityEngine;

public class GreenBrick : MonoBehaviour
{
    private int hitCount = 0; // Contador de hits para ladrillos verdes
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HandleHit(); // Manejar el hit del ladrillo verde
        }
    }

    // Método para manejar los hits de ladrillos verdes
    private void HandleHit()
    {
        hitCount++; // Incrementar el contador de hits

        if (hitCount >= 6) // Si se han recibido 3 hits
        {
            if (gameManager != null)
            {
              
                gameManager.levelcomplete();
            }
            Destroy(gameObject); // Destruir el ladrillo
        }
    }
}
