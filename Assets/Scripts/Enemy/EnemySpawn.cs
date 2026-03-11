using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawning")]
    private bool roomEntered;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] spawnPoints;

    [Header("Doors")]
    doorControl doorControl;

    [SerializeField] private GameObject spawnEffect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomEntered = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!roomEntered && collision.tag == "Player")
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                roomEntered = true;
                Instantiate(spawnEffect, spawnPoints[i].transform.position, Quaternion.identity);
                Instantiate(enemy, spawnPoints[i].transform.position, transform.rotation);
                
               
            }
            //doorControl.close();
        }
        
    }    
}
