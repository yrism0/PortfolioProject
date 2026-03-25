using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelchange : MonoBehaviour
{
    public UIManager Manager;
    public GameObject portal;
    public static bool LevelFinished = false;

    [SerializeField] private GameObject playerLegs;
    [SerializeField] private GameObject playerTorso;
    [SerializeField] private GameObject playerTeleportFX;


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
