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

    public static bool isPaused;

    [SerializeField] private PlayerRotation playerRotator; 




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
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        isPaused = false;
        playerRotator.enabled = true;
    }

    public void GoToMainMenu()
    {
        // Method used by Quit button on Pause Menu
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("main menu");
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
}
