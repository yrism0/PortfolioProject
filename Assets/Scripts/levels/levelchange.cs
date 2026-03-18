using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelchange : MonoBehaviour
{
    public UIManager Manager;
    public GameObject portal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIManager Manager = GetComponent<UIManager>();
    }

   

     void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            
            Manager.Endresults();

            
        }
    }

 
}
