using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    // M�todo p�blico que se llamar� cuando se presione el bot�n
    public void GoToStartScene()
    {
        // Cargar la escena de inicio
        SceneManager.LoadScene("Start");
    }
}
