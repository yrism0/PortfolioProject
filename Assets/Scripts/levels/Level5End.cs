using UnityEngine;

public class Level5End : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BeginEndSequence();
        }
    }

    private void BeginEndSequence()
    {

    }

    private void PlayerDisabled()
    {
        levelchange.LevelFinished = true;
        PlayerHealth.meterPause = true;
        UIManager.Instance.HideHUD();
        UIManager.Instance.isEnded = true;
    }
}

