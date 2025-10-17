using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para la gesti�n de escenas

public class PlayerController : MonoBehaviour
{
    // VARIABLES DEL JUGADOR
    private Rigidbody rb;
    public float velocidad;
    private int count;
    private bool gameIsFinished = false; // Bandera para evitar m�ltiples llamadas

    // VARIABLES DE UI
    public Text countText;
    public Text winText;
    public Text nameMatriculaText; // NUEVO: Para Nombre y Matr�cula

    // VARIABLES DE AUDIO
    public AudioSource cubeCollectSound; // NUEVO: Sonido al recoger cubos
    public AudioSource backgroundMusic;  // NUEVO: M�sica de ambiente

    // VARIABLES DEL JUEGO
    public int totalPickUps = 12; // IMPORTANTE: Define el total de coleccionables en este nivel

    void Start()
    {
        // Inicializaci�n
        rb = GetComponent<Rigidbody>();
        count = 0;
        gameIsFinished = false;
        SetCountText();
        winText.text = "";

        // Inicializar M�sica (debe estar marcada como NO Play On Awake en el Inspector)
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }

        // Asignar el nombre y la matr�cula (Ejemplo, puede ser asignado en el Inspector si prefieres)
        // nameMatriculaText.text = "Roberto Garc�a - 20230123";
    }

    void FixedUpdate()
    {
        // Solo permitir movimiento si el juego no ha terminado (ganado/perdido)
        if (!gameIsFinished)
        {
            float movimientoH = Input.GetAxis("Horizontal");
            float movimientoV = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

            rb.AddForce(movimiento * velocidad);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Evitar recoger objetos despu�s de ganar/perder
        if (gameIsFinished) return;

        // 1. L�gica para Cubo
        if (other.gameObject.CompareTag("CubePickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

            // Sonido para cubo
            if (cubeCollectSound != null)
            {
                cubeCollectSound.Play();
            }
        }
        // 2. L�gica para Anillo
        else if (other.gameObject.CompareTag("RingPickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

            // Apagar la m�sica al recoger un anillo
            if (backgroundMusic != null && backgroundMusic.isPlaying)
            {
                backgroundMusic.Stop();
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

        // Condici�n de Victoria
        if (count >= totalPickUps && !gameIsFinished)
        {
            gameIsFinished = true; // Establece la bandera de finalizaci�n

            // Detener el movimiento
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            winText.text = "�HAS GANADO!";

            // Verifica si es el �ltimo nivel o si hay m�s niveles
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                // Cargar el siguiente nivel a los 10 segundos
                Invoke("LoadNextLevel", 10.0f);
            }
            else
            {
                // Es el �ltimo nivel: volver al men� principal despu�s de 10 segundos
                Invoke("ReturnToMainMenu", 10.0f);
            }
        }
    }

    // FUNCI�N: Carga el nivel que sigue
    private void LoadNextLevel()
    {
        // Obtiene el �ndice de la escena actual en el Build Settings
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carga la escena con el siguiente �ndice
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // FUNCI�N: Regresa al men� principal (se usa al terminar el �ltimo nivel o al perder)
    public void ReturnToMainMenu()
    {
        // Carga la escena "MainMenu" (�ndice 0)
        SceneManager.LoadScene("MainMenu");
    }
}
