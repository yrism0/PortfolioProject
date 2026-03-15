using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelchange : MonoBehaviour
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
            StartCoroutine(LoadSceneWithFade("endofdemo"));
        }
    }

    IEnumerator LoadSceneWithFade(string sceneName)
    {
        // Start the fade-out effect
        yield return FadeManager.Instance.FadeOut();
        // Load the new scene
        SceneManager.LoadScene("endofdemo");
    }
}
