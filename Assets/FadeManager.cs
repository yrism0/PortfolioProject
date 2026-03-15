using System.Collections;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 0.5f;
    public static FadeManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
          
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    public IEnumerator FadeIn() //fade in the scene
    {

        fadeCanvasGroup.alpha = 1f;
           float t = 0;
            while ( t< fadeDuration)
            {
                t += Time.deltaTime;
                fadeCanvasGroup.alpha = 1f -(t / fadeDuration);
                yield return null;
            }
        fadeCanvasGroup.alpha = 0;

    }

    public IEnumerator FadeOut() //fade out the scene
    {
        fadeCanvasGroup.alpha = 0f;
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = t / fadeDuration;
            yield return null;
        }
        fadeCanvasGroup.alpha = 1f;
    }
}
