using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Funci�n para el bot�n "Iniciar Juego"
    public void StartGame()
    {
        SceneManager.LoadScene("Level_01"); // o el nombre de tu primer nivel
    }

    // Funci�n para el bot�n "Opciones/Controles"
    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    // Funci�n que se llama con el bot�n "Salir del Juego"
    public void QuitGame()
    {
        Application.Quit();
    }

    // NUEVA FUNCI�N: Vuelve al men� principal
    public void ReturnToMainMenu()
    {
        // Carga la escena "MainMenu", que debe tener el �ndice 0 en Build Settings
        SceneManager.LoadScene("MainMenu");
    }
}