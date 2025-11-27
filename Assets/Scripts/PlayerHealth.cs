using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Variables

    private float heatValue;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHeatValue = 30f;
        heatValue = maxHeatValue;
        playerCollider = GetComponent<CircleCollider2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInvincible == true)
        {
            iTime += Time.deltaTime;
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
            RestoreHealth(Random.Range(1,5));
        }
    }

    void UpdateHeatUI()
    {
        heatMeter.value = heatValue;
        heatMeter.maxValue = maxHeatValue;
               

    }

    public void TakeDamage(float damage)
    {
        if (playerInvincible == false)
        {
            heatValue -= damage;            
            playerCollider.enabled = false;
            playerInvincible = true;
            if (iTime >= iFrames)
            {
                playerCollider.enabled = true;
                playerInvincible = false;
                iTime = 0;
            }
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
