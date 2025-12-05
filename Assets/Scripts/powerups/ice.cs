using System.Collections;
using TopDown.Movement;
using UnityEngine;

public class ice : MonoBehaviour
{
    public GameObject iceup;
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
            StartCoroutine(iced());
            Destroy(iceup);
        }
    }
    IEnumerator iced()
    {
        PlayerHealth.meterPause = true;
        Debug.Log("chill off");
        yield return null;

    }
}
