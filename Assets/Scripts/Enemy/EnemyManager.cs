using SplatterSystem;
using System;
using System.Runtime.InteropServices;
using TopDown.Shooting;
using Unity.Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.AI;
using System.Runtime.CompilerServices;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    // Variables

    [Header("Splatter")]
    public MeshSplatterManager splatter;
    public SplatterSettings SplatterSettings;
    public Color splatterColour = Color.red;
    public float splatOffset = 0f;


    [Header("Enemy Variables")]
    [SerializeField] public float eHealth = 100f;
    public bool isDead = false;
    public int deathValue = 0;
    public EnemySpawn enemySpawn;

    [Header("Movement")]
    [SerializeField] Transform Target;
    NavMeshAgent agent;
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


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        //enemySpawn = GetComponent<EnemySpawn>();

        Target = GameObject.Find("Player").transform;
        splatter = GameObject.Find("SplatterSystemMesh").GetComponent<MeshSplatterManager>();


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
                Die();
                /*PlayerHealth.instance.RestoreHealth(10);
                CameraShakeManager.instance.CameraShake(impulseSource);
                animator.SetTrigger("isDead");
                isDead = true;
                splatter.Spawn(SplatterSettings, transform.position, null, splatterColour);
                boxCollider.isTrigger = true;
                speed = 0f;
                rotateSpeed = 0f;
                //enemySpawn.encounterSize--;*/
                
            }

            


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

    void Update()
    {
        FindPlayer(); 
       
        RotateTowardsTarget();
        
        

        if (Vector2.Distance(Target.position, transform.position) <= distanceToStop && isDead == false)
        {
            Shoot();
            
        }
    }


    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = Target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }


    

    public void SplatterHit(Vector2 direction)
    {
        Vector2 hitPos = (Vector2)transform.position + splatOffset * direction;
        splatter.Spawn(SplatterSettings, hitPos, direction, splatterColour);
    }

    public void FindPlayer()
    {
        if (isDead == false)
        {
            agent.SetDestination(Target.position);
        }
    }

    private void Die()
    {
        PlayerHealth.instance.RestoreHealth(10);
        CameraShakeManager.instance.CameraShake(impulseSource);
        animator.SetTrigger("isDead");
        isDead = true;
        splatter.Spawn(SplatterSettings, transform.position, null, splatterColour);
        boxCollider.isTrigger = true;
        speed = 0f;
        rotateSpeed = 0f;
        deathValue++;
    }

}
