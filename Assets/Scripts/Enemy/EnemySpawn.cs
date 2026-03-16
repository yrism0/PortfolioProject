using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    
    [Header("Spawning")]
    [SerializeField] private bool roomEntered;
   
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Encounters")]       
    [SerializeField] public int enemiesSpawned;
    private bool inEncounter;

    [Header("Other")]
    [SerializeField] private GameObject spawnEffect;
    [SerializeField] private Transform encounterParent;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomEntered = false;
        inEncounter = false;
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckEncounter();

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!roomEntered && collision.tag == "Player")
        {
            StartEncounter();
            boxCollider.enabled = false;

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                
                roomEntered = true;                
                Instantiate(spawnEffect, spawnPoints[i].transform.position, Quaternion.identity, encounterParent);                
                Instantiate(enemy, spawnPoints[i].transform.position, transform.rotation, encounterParent);
                enemiesSpawned++;
                if (enemiesSpawned == 0) // Moved here for testing - doesn't really work too well
                {
                    EndEncounter();
                }
                //encounterSize = i + 1;



            }
            
        }
        
    }

    
    
    private void StartEncounter()
    {
        inEncounter = true;
        enemiesSpawned = 0;
        doorControl.instance.Close();
        Debug.Log("Encounter Start");
    }

    private void EndEncounter()
    {
        //roomEntered = false;
        inEncounter = false;
        doorControl.instance.Open();
        Debug.Log("Encounter End");
    }

    private void CheckEncounter()
    {
        if (roomEntered && enemiesSpawned == 0 && inEncounter)
        {
            EndEncounter();
        }
    }
}
