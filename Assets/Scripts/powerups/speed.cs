using System.Collections;
using TopDown.Movement;
using UnityEngine;


public class speed : MonoBehaviour
{
    private powerupmanagement pManager;
    public GameObject speedup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pManager = GetComponentInParent<powerupmanagement>();
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
            Instantiate(pManager.pickUpEffect, transform.position, Quaternion.identity);
        }
    }

    IEnumerator hotfeet()
    {
        Mover.speedon = true;
        Debug.Log("gotta go fast");
        yield return null;
       
    }
}
