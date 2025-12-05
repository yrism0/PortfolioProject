using System.Collections;
using TopDown.Movement;
using UnityEngine;


public class speed : MonoBehaviour
{
    public GameObject speedup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            StartCoroutine(hotfeet());
            Destroy(speedup);
        }
    }

    IEnumerator hotfeet()
    {
        Mover.speedon = true;
        Debug.Log("gotta go fast");
        yield return null;
       
    }
}
