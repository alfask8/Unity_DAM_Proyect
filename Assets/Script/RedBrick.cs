using UnityEngine;

public class RedBrick : MonoBehaviour
{
    private int hitCount = 0; // Contador de hits
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HandleHit(); // Manejar el hit 
        }
    }

    // Método para manejar los hits de ladrillos rojos
    private void HandleHit()
    {
        hitCount++; // Incrementar el contador de hits

        if (hitCount >= 10) // Si se han recibido 4 hits
        {
            if (gameManager != null)
            {
              
                gameManager.levelcomplete();
            }
            Destroy(gameObject); // Destruir el ladrillo
        }
    }
}
