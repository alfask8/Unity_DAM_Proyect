using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        
            
        PersistentAudio persistentAudio = FindObjectOfType<PersistentAudio>();
        if (persistentAudio != null)
        {
            persistentAudio.StopAndDestroyAudio();
        }

        // Cargar la siguiente escena
        SceneManager.LoadScene("Level 1");
        
    }
}
