using UnityEngine;

public class PlayerIntro : MonoBehaviour
{
    [SerializeField] private GameObject teleportFX;
    [SerializeField] private Transform playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(teleportFX, playerPos.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
