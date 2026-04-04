using UnityEngine;

public class Level5End : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerDisabled();
            BeginEndSequence();
        }
    }

    private void BeginEndSequence()
    {
        playerAnimator.SetTrigger("GameEnd");
         
    }

    private void PlayerDisabled()
    {
        levelchange.LevelFinished = true;
        PlayerHealth.meterPause = true;
        UIManager.Instance.HideHUD();
        UIManager.Instance.isEnded = true;
        PlayerHealth.instance.DisablePlayerMovement();
    }
}

