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
    public GameTimer gameTimer;

    public bool isEnded;
    public bool isPaused;

    [SerializeField] private PlayerRotation playerRotator;

    [Header("HUD")]
    [SerializeField] private Text heatText;
    private Color defaultTextColor = new Color32(50, 50, 50, 255);
    
    [SerializeField] public GameObject ammoUI;
    [SerializeField] public Slider shotSlider;
    [SerializeField] public Slider timerSlider;
    [SerializeField] public Slider cooldownSlider;
    [SerializeField] public Image cooldownFill;









    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       gameTimer = GetComponent<GameTimer>();
        isEnded = false;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isEnded)
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
        gameTimer.SetFinalTime();
        endResultMenu.SetActive(true);
        isPaused = true;
        playerRotator.enabled = false;
        HideHUD();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isEnded = true;
       
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
        HideHUD();
        gameOverScreen.SetActive(true);
        gameTimer.SetFinalTime();
        isEnded = true;
    }

    public void HideGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }

    public void ShowAmmoUI()
    {
        ammoUI.SetActive(true);
    }

    public void HideAmmoUI()
    {
        ammoUI.SetActive(false);
    }
}

