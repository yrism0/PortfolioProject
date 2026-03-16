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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
