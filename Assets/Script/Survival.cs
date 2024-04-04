using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Survival : MonoBehaviour
{
    // M�todo p�blico que se llamar� cuando se presione el bot�n
    public void GoToLevel()
    {

        PersistentAudio persistentAudio = FindObjectOfType<PersistentAudio>();
        if (persistentAudio != null)
        {
            persistentAudio.StopAndDestroyAudio();
        }
        // Cargar la escena de inicio
        SceneManager.LoadScene("LevelGenerator");
    }
}

