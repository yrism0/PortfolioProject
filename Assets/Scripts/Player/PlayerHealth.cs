using TopDown.Movement;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    // Variables

    [Header("Player Attributes")]
    [SerializeField] private GameObject player;

    public float heatValue;
    private float maxHeatValue;

    private float lerpTimer;
    public float chipSpeed = 2f;

    public bool isPlayerDead;
    [SerializeField] GameObject playerDeathFX;
    [SerializeField] GameObject playerDeathSmoke;
    [SerializeField] Transform smokePoint;
    [SerializeField] Animator playerAnimator;
    private PlayerMovement plMove;
    private PlayerRotation plRotate;

    [Header("Invincibility Frames")]
    [SerializeField] private float iFrames;
    private float iTime;
    [SerializeField] private bool playerInvincible = false;
    private CircleCollider2D playerCollider;
        

    [Header("Heat Meter")]
    public static bool meterPause;
    public Slider heatMeter;

    [SerializeField] private Image heatMeterFill;    
    private Color defaultHUD = new Color32(255, 157, 0, 255);
    private Color frozenHUD = new Color32(181, 235, 255, 255);
    
    
    private CinemachineImpulseSource impulseSource;

    

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        isPlayerDead = false;
        meterPause = false;
        maxHeatValue = 15f;
        heatValue = maxHeatValue;        
        playerCollider = GetComponent<CircleCollider2D>();  
        impulseSource = GetComponent<CinemachineImpulseSource>();
        plMove = GetComponent<PlayerMovement>();
        plRotate = GetComponent<PlayerRotation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInvincible == true)
        {
            iTime += Time.deltaTime;
            if (iTime >= iFrames)
            {      
                playerInvincible = false;
                iTime = 0;
            }
        }
        

        heatValue = Mathf.Clamp(heatValue, 0 , maxHeatValue);
        UpdateHeatUI();
        if (meterPause == false)
        {
            heatValue -= Time.deltaTime;
        }
        else
        {
            return;
        }


            


        if (Input.GetKeyDown(KeyCode.K))
        {
            
            TakeDamage(Random.Range(1,5));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            RestoreHealth(Random.Range(1,5));
        }

        // Player Death - Will be disabled for now
        if (heatValue <= 0 && !isPlayerDead)
        {
            
            PlayerDeath();
        }
        
    }

    void UpdateHeatUI()
    {
        heatMeter.value = heatValue;
        heatMeter.maxValue = maxHeatValue;
        
        if (meterPause)
        {
            heatMeterFill.color = frozenHUD;
        }
        else
        {
            if (heatMeter.value < 5)
            {
                heatMeterFill.color = Color.red;
            }
            else
            {
                heatMeterFill.color = defaultHUD;
            }
             
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && playerInvincible == false)
        {            
            TakeDamage(10);
        }
    }

    public void TakeDamage(float damage)
    {
        if (playerInvincible == false)
        {
            CameraShakeManager.instance.CameraShake(impulseSource);

            heatValue -= damage;            
            playerInvincible = true;
            
        }
        else
        {
            return;
        }
        
        
        
    }

    public void RestoreHealth(float healAmount)
    {
        heatValue += healAmount;
        
    }

    public void PlayerDeath()
    {
        isPlayerDead = true;

        Instantiate(playerDeathFX, transform.position, Quaternion.identity);
        Instantiate(playerDeathSmoke, smokePoint.position, smokePoint.rotation);

        playerAnimator.SetTrigger("IsDead");
        plMove.movementSpeed = 0;

        UIManager.Instance.HeatDeath();
        UIManager.Instance.ShowGameOverScreen();

        playerCollider.enabled = false;

    }
    
    public void DisablePlayerMovement()
    {
        plMove.movementSpeed = 0;
        playerCollider.enabled = false;
    }

}
