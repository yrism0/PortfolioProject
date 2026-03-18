using System.Collections;
using TopDown.Movement;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    // Variables

    [Header("Screens")]
    [SerializeField] private GameObject playerHUD;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endResultMenu;
    [SerializeField] private GameObject gameOverScreen;
    

    public bool isPaused;

    [SerializeField] private PlayerRotation playerRotator;

    [SerializeField] private Text heatText;
    private Color defaultTextColor = new Color32(50, 50, 50, 255);






    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                PauseGame();

            }
            else if (isPaused == true)
            {
                ResumeGame();
            }
        }
    }

    
    public void PauseGame()
    {
        Time.timeScale = 0f; 
        pauseMenu.SetActive(true);
        isPaused = true;
        playerRotator.enabled = false;
        HideHUD();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        isPaused = false;
        playerRotator.enabled = true;
        ShowHUD();
    }

    public void GoToMainMenu()
    {
        // Method used by Quit button on Pause Menu
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("main menu");
    }
    public void Endresults()
    {
        Time.timeScale = 0f;
        endResultMenu.SetActive(true);
        isPaused = true;
        playerRotator.enabled = false;
        HideHUD();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GoToNextLevel()
    {
        // StartCoroutine(LoadSceneWithFade("endofdemo"));
        SceneManager.LoadScene("endofdemo");

    }
    public void HideHUD()
    {
        playerHUD.SetActive(false);
    }

    public void ShowHUD()
    {
        playerHUD.SetActive(true);
    }

    public void replay()
    {
        SceneManager.LoadScene("LevelTest");
    }

    IEnumerator LoadSceneWithFade(string sceneName)
    {
        // Start the fade-out effect
        yield return FadeManager.Instance.FadeOut();
        // Load the new scene
        SceneManager.LoadScene("endofdemo");
    }
    public void HeatDeath()
    {
        heatText.text = ">DEAD///";
        heatText.color = Color.red;
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}
