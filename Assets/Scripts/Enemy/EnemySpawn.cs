using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawning")]
    private bool roomEntered;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] spawnPoints;

    [Header("Encounters")]
    //public doorControl doorControl;
    //public EnemyManager enemyManager;
    //public int encounterSize;

    [Header("Other")]
    [SerializeField] private GameObject spawnEffect;
    [SerializeField] private Transform encounterParent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //enemyManager = GetComponent<EnemyManager>();
        //doorControl = GetComponent<doorControl>();
        roomEntered = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        /*if (encounterSize == 0)
        {
            EndEncounter();
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!roomEntered && collision.tag == "Player")
        {
            //StartEncounter();

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                
                roomEntered = true;
                Instantiate(spawnEffect, spawnPoints[i].transform.position, Quaternion.identity, encounterParent);                
                Instantiate(enemy, spawnPoints[i].transform.position, transform.rotation, encounterParent);
                //encounterSize = i;                
                
                
            }
            
        }
        
    }
    
    /*private void StartEncounter()
    {
        doorControl.Close();
    }

    private void EndEncounter()
    {
        doorControl.Open();
    }*/
}
