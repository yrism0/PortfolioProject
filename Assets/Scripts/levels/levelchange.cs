using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelchange : MonoBehaviour
{
    public UIManager Manager;
    public GameTimer Timer;
    public GameObject portal;
    public static bool LevelFinished = false;

    [SerializeField] private GameObject playerLegs;
    [SerializeField] private GameObject playerTorso;
    [SerializeField] private GameObject playerTeleportFX;

    [Header("Grade Thresholds")]
    private float gradeA = 45f;
    private float gradeB = 60f;
    private float gradeC = 80f;
    private float gradeF;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LevelFinished = false;
        UIManager Manager = GetComponent<UIManager>();
    }

   

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(playerTeleportFX, collision.transform.position, Quaternion.identity);
            StartCoroutine(EndSequence()); 
            float elapsedTime = Timer.ElapsedTime; // Access the elapsed time from the GameTimer script
            string grade = CalculateGrade(elapsedTime).ToString(); // Calculate the grade based on the elapsed time
        }
    }

    public static int CalculateGrade(float gameTime)
    {
        if (gameTime <= 30f) //Grade A threshold
        {
            return 'A'; 
        }
        else if (gameTime <= 45f) //Grade B threshold
        {
            return 'B';
        }
        else if (gameTime <= 60f)   //Grade C threshold
        {
            return 'C';
        }
        else //Grade F for times above 1 min 20 seconds
        {
            return 'F';
        }
    }
    IEnumerator EndSequence()
    {
        LevelFinished = true;
        
        HidePlayer();
        PlayerHealth.instance.DisablePlayerMovement();
        yield return new WaitForSeconds(1);
        Manager.Endresults();
    }

    private void HidePlayer()
    {
        playerLegs.SetActive(false);
        playerTorso.SetActive(false);
    }

 
}
