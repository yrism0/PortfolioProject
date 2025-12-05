using SplatterSystem;
using System;
using System.Runtime.InteropServices;
using TopDown.Shooting;
using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
    private bool isDead = false;

    [Header("Movement")]
    public Transform target;
    public float speed = 1f;
    public float rotateSpeed = 0.05f;
    private Rigidbody2D rb;

    [Header("Shooting")]
    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;

    public float fireRate;
    private float timeToFire;

    public Transform firingPoint;
    public GameObject enemyBullet;

    private Animator animator;
    private BoxCollider2D boxCollider;
    private CinemachineImpulseSource impulseSource;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
                eHealth -= 100f;               
            }
            else if (eHealth <= 0)
            {
               
                PlayerHealth.instance.RestoreHealth(10);
                CameraShakeManager.instance.CameraShake(impulseSource);
                animator.SetTrigger("isDead");
                isDead = true;
                splatter.Spawn(SplatterSettings, transform.position, null, splatterColour);
                boxCollider.isTrigger = true;

                speed = 0f;
                rotateSpeed = 0f;
                
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

    private void Shoot()
    {
        if (timeToFire <= 0f)
        {            
            GameObject eBullet = Instantiate(enemyBullet, firingPoint.position, firingPoint.rotation);
            eBullet.GetComponent<Projectile>().ShootBullet(firingPoint);
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    private void Update()
    {
       if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        if (Vector2.Distance(target.position, transform.position) <= distanceToStop && isDead == false)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
            {
                rb.linearVelocity = transform.up * speed;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
        
        
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
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
