using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
          
            gameManager.levelcomplete(); // Comprobar si se ha completado el nivel

            Destroy(gameObject);
        }
    }
}
