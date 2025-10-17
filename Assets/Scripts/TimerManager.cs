using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 60f; // Tiempo inicial en segundos
    public Text timerText;          // Referencia al texto de la UI
    public GameObject player;       // Referencia al jugador (esfera)
    public Text loseText;           // Texto que aparece al perder

    private bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
        loseText.text = ""; // Inicialmente vac�o
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Restar el tiempo desde el �ltimo frame
                DisplayTime(timeRemaining);
            }
            else
            {
                // TIEMPO TERMINADO: Condici�n de DERROTA
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                LoseGame();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Para que muestre 60, no 59 al inicio

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Formato MM:SS
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void LoseGame()
    {
        // 1. Mostrar mensaje de derrota
        loseText.text = "�TIEMPO TERMINADO! PERDISTE.";

        // 2. Detener al jugador
        if (player != null)
        {
            player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.GetComponent<PlayerController>().enabled = false; // Deshabilitar movimiento
        }

        // 3. Volver a la escena principal despu�s de 10 segundos
        Invoke("ReturnToMainMenu", 10.0f);
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}