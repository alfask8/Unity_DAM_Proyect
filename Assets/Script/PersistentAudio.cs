using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    private static PersistentAudio instance;

    private void Awake()
    {
        // Si no existe una instancia del objeto de audio, establece esta como la instancia actual.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cargar una nueva escena.
        }
        else
        {
            // Si ya existe una instancia, destruir este objeto para evitar duplicados.
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Reproducir el audio.
        GetComponent<AudioSource>().Play();
    }

    public void StopAndDestroyAudio()
    {
        GetComponent<AudioSource>().Stop();
        Destroy(gameObject);
    }
}
