using UnityEngine;

public class Reheat : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth.instance.RestoreHealth(30);
            Destroy(this.gameObject);
            Instantiate(pManager.pickUpEffect, transform.position, Quaternion.identity);
        }
    }
}
