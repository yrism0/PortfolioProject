using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Levels")]
    public string level1 = "Level 1";
    public string level2 = "Level 2";
    public string level3 = "Level 3";
    public string level4 = "Level 4";
    public string level5 = "Level 5";
    public string mainMenu = "Main Menu";
    public string endScene = "EndScene";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel1() // Always Unlocked
    {
        SceneManager.LoadScene(level1);
        Time.timeScale = 1f;
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(level2);
        Time.timeScale = 1f;
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene(level3);
        Time.timeScale = 1f;
    }

    public void StartLevel4() // Always Unlocked
    {
        SceneManager.LoadScene(level4);
        Time.timeScale = 1f;
    }

    public void StartLevel5()
    {
        SceneManager.LoadScene(level5);
        Time.timeScale = 1f;
    }

    public void StartMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    public void StartEndScene()
    {
        SceneManager.LoadScene(endScene);
        Time.timeScale = 1f;
    }
}
