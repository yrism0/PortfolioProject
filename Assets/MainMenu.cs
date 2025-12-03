using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This script will control the main menu behaviours

    public void StartGame()
    {
        SceneManager.LoadScene("LevelTest");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();
    }
}
