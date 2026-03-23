using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    private float gameTimer;
    private float finalGameTime;
    private Text timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
    }

    public void FinalTime()
    {
        finalGameTime = gameTimer;
    }

    public void SetUIText()
    {
        
    }
}
