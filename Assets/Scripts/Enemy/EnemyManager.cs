using SplatterSystem;
using System;
using System.Runtime.InteropServices;
using Unity.Cinemachine;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Variables

    [Header("Splatter")]
    public MeshSplatterManager splatter;
    public SplatterSettings SplatterSettings;
    public Color splatterColour = Color.red;
    public float splatOffset = 0f;

    [Header("Enemy Variables")]
    [SerializeField] private float eHealth = 100f;

    private Animator animator;
    private BoxCollider2D boxCollider;
    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pBullet")
        {
            Debug.Log("HIT");

            if (eHealth > 0)
            {
                eHealth -= 25f;               
            }
            else if (eHealth <= 0)
            {
                PlayerHealth.instance.RestoreHealth(10);
                CameraShakeManager.instance.CameraShake(impulseSource);
                animator.SetTrigger("isDead");
                splatter.Spawn(SplatterSettings, transform.position, null, splatterColour);
                boxCollider.isTrigger = true;
            }

            // Take Damage

            // IF health = 0 THEN enemyDeath()

            // Splatter blood


        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pBullet")
        {
            splatter.Spawn(SplatterSettings, transform.position, null, splatterColour);
        }
    }

    private void EnemyDamage()
    {

    }

    private void EnemyDeath()
    {
        // Enemy dies

        // Splatter more blood
    }

    public void SplatterHit(Vector2 direction)
    {
        Vector2 hitPos = (Vector2)transform.position + splatOffset * direction;
        splatter.Spawn(SplatterSettings, hitPos, direction, splatterColour);
    }
   
}
