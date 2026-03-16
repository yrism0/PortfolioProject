using JetBrains.Annotations;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    
    [Header("Spawning")]
    private bool roomEntered;
    private EnemyManager enemyInEncounter;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] spawnPoints;

    [Header("Encounters")]
    //public doorControl doorControl;
    //public EnemyManager enemyManager;
    private bool encounterStarted;
    public int encounterSize;
    [SerializeField] private int enemiesSpawned;

    [Header("Other")]
    [SerializeField] private GameObject spawnEffect;
    [SerializeField] private Transform encounterParent;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //enemyManager = GetComponent<EnemyManager>();
        enemyInEncounter = enemy.GetComponent<EnemyManager>();
        roomEntered = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        // NONE OF THIS SHIT WORKS
        // IT CANT DETECT WHEN THE ENEMIES DIE FOR WHATEVER REASON
       
        if (EnemyManager.instance.isDead == true && enemiesSpawned > 0 && encounterStarted)
        {
            Debug.Log("Enemy DEAD!!!!!"); // PICKS IT UP NOW, WILL NOT DECREASE BY 1; PROBABLY DUE TO BEING IN UPDATE.
            enemiesSpawned -= 1;
            if (enemiesSpawned == 0)
            {
                EndEncounter();
            }
            //encounterSize -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!roomEntered && collision.tag == "Player")
        {
            StartEncounter();
            

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                
                roomEntered = true;                
                Instantiate(spawnEffect, spawnPoints[i].transform.position, Quaternion.identity, encounterParent);                
                Instantiate(enemy, spawnPoints[i].transform.position, transform.rotation, encounterParent);
                enemiesSpawned++;
                //encounterSize = i + 1;


                
            }
            
        }
        
    }

    
    
    private void StartEncounter()
    {
        encounterStarted = true;
        doorControl.instance.Close();
    }

    private void EndEncounter()
    {
        encounterStarted = false;
        doorControl.instance.Open();
    }
}
