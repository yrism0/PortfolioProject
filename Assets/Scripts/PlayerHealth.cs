using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    // Variables

    public float heatValue;
    private float maxHeatValue;

    [Header("Invincibility Frames")]
    [SerializeField] private float iFrames;
    private float iTime;
    [SerializeField] private bool playerInvincible = false;
    private CircleCollider2D playerCollider;

    private float lerpTimer;
    public float chipSpeed = 2f;

    public bool meterPause;
    public Slider heatMeter;
    public Slider healingBMeter;

    
    private CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHeatValue = 30f;
        heatValue = maxHeatValue;
        playerCollider = GetComponent<CircleCollider2D>();  
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInvincible == true)
        {
            iTime += Time.deltaTime;
            if (iTime >= iFrames)
            {
               
                playerCollider.enabled = true;
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


            healingBMeter.value = heatMeter.value;


        if (Input.GetKeyDown(KeyCode.K))
        {
            
            TakeDamage(Random.Range(1,5));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            CameraShakeManager.instance.CameraShake(impulseSource);
            RestoreHealth(Random.Range(1,5));
        }

        
    }

    void UpdateHeatUI()
    {
        heatMeter.value = heatValue;
        heatMeter.maxValue = maxHeatValue;
               

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && playerInvincible == false)
        {
            CameraShakeManager.instance.CameraShake(impulseSource);
            TakeDamage(10);
        }
    }

    public void TakeDamage(float damage)
    {
        if (playerInvincible == false)
        {
            CameraShakeManager.instance.CameraShake(impulseSource);

            heatValue -= damage;            
            //playerCollider.enabled = false;
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

   
    

}
