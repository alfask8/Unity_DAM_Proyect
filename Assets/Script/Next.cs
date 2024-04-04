using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Obtener el índice de la escena actual.
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // Cargar la siguiente escena (incrementar el índice en 1).
        SceneManager.LoadScene(currentIndex + 1);
    }
}
