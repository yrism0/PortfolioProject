using TopDown.Shooting;
using UnityEngine;

public class FormLock : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangingFormAnimFlag()
    {
        // Called via Animation Flag
        GunController.changingForm = false;
    }

}
