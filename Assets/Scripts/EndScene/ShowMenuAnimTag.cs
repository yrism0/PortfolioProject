using UnityEngine;

public class ShowMenuAnimTag : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private void Start()
    {
        menu.SetActive(false);
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
    }
}
