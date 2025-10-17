using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Función para el botón "Iniciar Juego"
    public void StartGame()
    {
        SceneManager.LoadScene("Level_01"); // o el nombre de tu primer nivel
    }

    // Función para el botón "Opciones/Controles"
    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    // Función que se llama con el botón "Salir del Juego"
    public void QuitGame()
    {
        Application.Quit();
    }

    // NUEVA FUNCIÓN: Vuelve al menú principal
    public void ReturnToMainMenu()
    {
        // Carga la escena "MainMenu", que debe tener el Índice 0 en Build Settings
        SceneManager.LoadScene("MainMenu");
    }
}