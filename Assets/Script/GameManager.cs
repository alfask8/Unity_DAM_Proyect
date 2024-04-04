using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int lives = 3;
    private bool isPaused = false; // Verifica si el juego está pausado
    public Text livesText; // Referencia al texto de las vidas
    public Text pauseText; // Referencia al texto de pausa
    private Player player; // Referencia al script Player para desactivar el movimiento durante la pausa

    private void Start()
    {
        player = FindObjectOfType<Player>(); // Obtener la referencia al script Player

        UpdateLivesText(); // Actualización vidas
     
        pauseText.text = ""; // Inicialmente, el texto de pausa está vacío.Se hace para iniciar la variable al comienzo de la escena.
    }

    private void Update()
    {
        // Verificar si se ha pulsado la tecla Space para pausar el juego.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

        if (isPaused)
        {
            return;
        }

    }

    private void TogglePause()
    {
        isPaused = !isPaused; // Cambiar el estado del juego.

        // Si el juego está pausado, detener el tiempo, desactivar el movimiento del jugador y mostrar el texto de pausa.
        if (isPaused)
        {
            Time.timeScale = 0;
            player.enabled = false;
            pauseText.text = "PAUSE";
           
        }
        else // Si no está pausado, reanudar el tiempo, activar el movimiento del jugador y ocultar el texto de pausa.
        {
            Time.timeScale = 1;
            player.enabled = true; // Activar el movimiento del jugador.
            pauseText.text = "";
           
        }
    }

    public int Lives => lives;

    public void LostLives()
    {
        lives--;
        UpdateLivesText();

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
            
        }
    }


    public void levelcomplete()
    {
        if (transform.childCount <= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void UpdateLivesText()
    {
        livesText.text = "LIVES: " + lives.ToString();
    }



    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Si se está ejecutando una compilación, salir de la aplicación
#endif
    }
}
    


