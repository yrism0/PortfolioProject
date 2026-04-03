using System.Collections;
using UnityEngine;

public class EndExplosion : MonoBehaviour
{

    //[SerializeField] private GameObject explosion;
    //[SerializeField] private Transform expTransform;

    [SerializeField] private float duration = 2f;
    [SerializeField] private Vector3 scale = new Vector3(1f, 1f, 1f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //expTransform = GetComponent<Transform>();
        StartCoroutine(IncreaseScale(duration, scale));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IncreaseScale(float duration, Vector3 scale)
    {
        Vector3 startScale = transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, scale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = scale;
    }
}
