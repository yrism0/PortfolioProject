using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    // Variables

    [Header("Screens")]
    [SerializeField] private GameObject playerHUD;
    [SerializeField] private GameObject pauseMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu?.SetActive(false);
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
