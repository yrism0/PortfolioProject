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
        }
    }

    public void PauseGame()
    {
        
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu?.SetActive(false);
        isPaused = false;
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
}
