using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Variables

    private float heatValue;
    private float maxHeatValue;
    

    private float lerpTimer;
    public float chipSpeed = 2f;

    public Slider heatMeter;
    public Slider healingBMeter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHeatValue = 30f;
        heatValue = maxHeatValue;
        
    }

    // Update is called once per frame
    void Update()
    {        
        heatValue = Mathf.Clamp(heatValue, 0 , maxHeatValue);
        heatValue -= Time.deltaTime;
        UpdateHeatUI();
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
        heatValue -= damage;
        lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmount)
    {
        heatValue += healAmount;
        lerpTimer = 0f;
    }
}
