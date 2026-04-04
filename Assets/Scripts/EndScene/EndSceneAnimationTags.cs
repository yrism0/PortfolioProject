using UnityEngine;

public class EndSceneAnimationTags : MonoBehaviour
{
    [SerializeField] private Animator explosionAnimator;
    [SerializeField] private Animator shipAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartExplosion()
    {
        explosionAnimator.SetTrigger("Explode");
    }

    public void ShrinkStation()
    {
        shipAnimator.SetTrigger("Hide");
    }
}
