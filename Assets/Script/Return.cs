using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    // Método público que se llamará cuando se presione el botón
    public void GoToStartScene()
    {
        // Cargar la escena de inicio
        SceneManager.LoadScene("Start");
    }
}
