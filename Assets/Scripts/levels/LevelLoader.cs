using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Levels")]
    public string level1 = "Level1";
    public string level2 = "Level2";
    public string level3 = "Level3";
    public string level4 = "Level4";
    public string level5 = "Level5";
    public string mainMenu = "MainMenu";

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
}
