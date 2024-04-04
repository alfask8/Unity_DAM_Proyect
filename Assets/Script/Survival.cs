using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Survival : MonoBehaviour
{
    // Método público que se llamará cuando se presione el botón
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

