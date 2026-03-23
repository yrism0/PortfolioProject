using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
