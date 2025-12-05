using TopDown.Movement;
using UnityEngine;
using System.Collections;

public class powerupmanagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mover.speedon == true)
        {
            StartCoroutine(hotfeetend());
        }
        if (PlayerHealth.meterPause == true)
        {
            StartCoroutine(flameon());
        }
    }

    IEnumerator hotfeetend()
    {
        
        yield return new WaitForSeconds(10);
        Mover.speedon = false;
        Debug.Log("times up");
    }

    IEnumerator flameon()
    {
        yield return new WaitForSeconds(10);
        PlayerHealth.meterPause = false;
        Debug.Log("hot pot");

    }
}
