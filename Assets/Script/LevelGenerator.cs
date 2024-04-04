using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] brickPrefabs;
    public Text livesText;
    private int totalBricks = 30; //Si ponemos m�s peta!!
    private float minDistance = 0.5f; // Distancia m�nima entre ladrillos para que no haya solapamiento. ojo que si ponemos m�s peta, asi que mejor dejarlo privado.
    
    private GameManager gameManager;
    private List<Vector3> generatedPositions = new List<Vector3>(); // Lista para almacenar las posiciones de los ladrillos generados de manera random.

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //Referenciamos al script del gamemanager.
        GenerateLevel();
    }

    void Update()
    {
        CheckLevelCompletion();
        CheckRegenerateBricks();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < totalBricks; i++) //Con un buble generamos ladrillos en posiciones aleatorioas entre un minimo y un maximo en los dos ejes, para que est�n siempre en pantalla y no se salgan.
        {
            float xPos;
            float yPos;

            do
            {
                xPos = Random.Range(-2f, 2f);  // Ajustamos los l�mites de X
                yPos = Random.Range(-3f, 3f); // L�mites de Y
            } while (!IsPositionValid(new Vector3(xPos, yPos, 0))); // Verificar si la posici�n es v�lida. Con eso el programa comprueb si pone un ladrillo fuera y lo recoloca! Chulo eh?

            GameObject brickPrefab = brickPrefabs[Random.Range(0, brickPrefabs.Length)]; //Con esto seleccionamos el tipo de prefabs de ladrillos a meter en la escena, siendo tambien aleatoria su selection.

            GameObject brick = Instantiate(brickPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);  // instancia los ladrillos en la posicion, bloqueando la rotacion por si acaso se salen de la escena o algo.
            brick.transform.parent = gameManager.transform;  // Hacer que el ladrillo sea hijo del GameManager, para poder contar los que faltan y que la escena siga regenerandose.
            generatedPositions.Add(new Vector3(xPos, yPos, 0)); // Agregar la posici�n generada a la lista
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 generatedPosition in generatedPositions)
        {
            if (Vector3.Distance(position, generatedPosition) < minDistance)
            {
                return false; // La posici�n no es v�lida si la distancia es menor que la distancia m�nima
            }
        }
        return true; // La posici�n es v�lida si no se encontr� ninguna posici�n cercana.
    }

    void CheckLevelCompletion()
    {
        if (gameManager != null && gameManager.transform.childCount <= 0)
        {
            if (gameManager.Lives <= 0)
            {                               
                SceneManager.LoadScene("GameOver");
            }
            
        }
    }

   

    void CheckRegenerateBricks()
    {
        // Verificar si al GameManager le faltan dos hijos
        if (gameManager != null && gameManager.transform.childCount <= 1)
        {
            RegenerateBricks();
        }
    }

    void RegenerateBricks()
    {
        // Limpiar la lista de posiciones generadas
        generatedPositions.Clear();

        // Destruir los ladrillos actuales
        foreach (Transform child in gameManager.transform)
        {
            Destroy(child.gameObject);
        }

        // Generar nuevos ladrillos
        GenerateLevel();
    }
}
