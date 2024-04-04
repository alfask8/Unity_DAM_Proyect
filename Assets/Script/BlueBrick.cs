using UnityEngine;

public class BlueBrick : MonoBehaviour
{
    private int hitCount = 0; // Contador de hits para ladrillos azules
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HandleHit(); // Manejar el hit del ladrillo azul
        }
    }

    // Método para manejar los hits de ladrillos azules
    private void HandleHit()
    {
        hitCount++; // Incrementar el contador de hits

        if (hitCount >= 3) // Si se han recibido 2 hits
        {
            if (gameManager != null)
            {
               
                gameManager.levelcomplete();
            }
            Destroy(gameObject); // Destruir el ladrillo
        }
    }
}
