using UnityEngine;
using UnityEngine.UI;

public class ShowMenuAnimTag : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private float finalTime;
    [SerializeField] private Text timerText;

    private void Start()
    {
        finalTime = PlayerPrefs.GetFloat("save");
        timeMath();
        menu.SetActive(false);
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
    }

    private void timeMath()
    {
        int finalSec = (int)finalTime % 60;
        int finalMin = (int)finalTime / 60;
        int finalMSec = (int)(finalTime * 100) % 100;

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", finalMin, finalSec, finalMSec);
    }
}
