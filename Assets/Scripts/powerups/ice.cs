using System.Collections;
using TopDown.Movement;
using UnityEngine;

public class ice : MonoBehaviour
{

    private float frozenTimer;
    public GameObject iceup;
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
            StartCoroutine(iced());
            Destroy(iceup);
        }
    }
    IEnumerator iced()
    {
       
        frozenTimer += Time.deltaTime;
        if (frozenTimer >= 10)
        {           
            PlayerHealth.meterPause = false;
        }
        
        PlayerHealth.meterPause = true;
        Debug.Log("chill off");
        yield return null;

    }
}
