using TopDown.Movement;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LegsAnimation : MonoBehaviour
{
    [SerializeField] private Mover playerMover;
    private Animator legsAnimator;

    private void Awake()
    {
        legsAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!UIManager.Instance.isPaused && !PlayerHealth.instance.isPlayerDead)
        { 
            legsAnimator.SetBool("moving", playerMover.CurrentInput != Vector3.zero);        
        }
        if (PlayerHealth.instance.isPlayerDead)
        {
            legsAnimator.SetBool("moving", false);
        }
    }
}
