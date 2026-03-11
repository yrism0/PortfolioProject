using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private bool roomEntered;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] spawnPoints;
    doorControl doorControl;
    
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
        if (!roomEntered)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                roomEntered = true;
                Instantiate(enemy, spawnPoints[i].transform.position, transform.rotation);
               
            }
            //doorControl.close();
        }
        
    }
}
