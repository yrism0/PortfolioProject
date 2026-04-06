using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject credits;
    [SerializeField] private Animator camAnim;
    [SerializeField] private GameObject slFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void GameStart()
    {
        slFX.SetActive(true);
        menu.SetActive(false);
        camAnim.SetTrigger("Start");
    }
}
