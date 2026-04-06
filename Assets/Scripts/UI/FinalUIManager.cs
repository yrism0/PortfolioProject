using UnityEngine;

public class FinalUIManager : MonoBehaviour
{
    [SerializeField] private GameObject creditScreen;
    [SerializeField] private GameObject finalMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creditScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCredits()
    {
        creditScreen.SetActive(true);
        finalMenu.SetActive(false);
    }
}
