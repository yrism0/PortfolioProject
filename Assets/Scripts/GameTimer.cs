using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    private float gameTimer;
    private float finalGameTime;
    [SerializeField] private Text timerText;
    [SerializeField] private Text finalTimerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTimer = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;

       SetUIText();
    }

    public void SetFinalTime()
    {
        // Finalises the Timer to be displayed during the results screen
        int finalSec = (int)gameTimer % 60;
        int finalMin = (int)gameTimer / 60;
        int finalMSec = (int)(gameTimer * 100) % 100;
        finalGameTime = (int)gameTimer;

        // Formats the text to show Minutes, Seconds, and Milliseconds (00:00.00)
        finalTimerText.text = string.Format("{0:00}:{1:00}.{2:00}", finalMin, finalSec, finalMSec);
        
    }

    public void SetUIText()
    {
        // Maths to create seconds and minutes
        int seconds = (int)gameTimer % 60;
        int minutes = (int)gameTimer / 60;
        int mSeconds = (int)(gameTimer * 100) % 100;

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, mSeconds);
    }
}
