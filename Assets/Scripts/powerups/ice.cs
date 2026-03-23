using System.Collections;
using TopDown.Movement;
using UnityEngine;

public class ice : MonoBehaviour
{

    private float frozenTimer;
    public GameObject iceup;
    private powerupmanagement pManager;

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
            Debug.Log(frozenTimer);
            StartCoroutine(iced());
            Destroy(iceup);
            Instantiate(pManager.pickUpEffect, transform.position, Quaternion.identity);
        }
    }
    IEnumerator iced()
    {
       
        frozenTimer += Time.deltaTime;
        if (frozenTimer >= 10)
        {           
            PlayerHealth.meterPause = false;
            frozenTimer = 0;

        }
        
        PlayerHealth.meterPause = true;
        Debug.Log("chill off");
        yield return null;

    }
}
