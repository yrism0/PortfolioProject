using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelchagne : MonoBehaviour
{
    public GameObject portal;
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
            SceneManager.LoadScene("level2");
        }
    }
}
