using TopDown.Movement;
using UnityEngine;

public class doorControl : MonoBehaviour
{

    public static doorControl instance;
    
    [SerializeField] private GameObject doors;
    [SerializeField] private bool isOpen;
    [SerializeField] private Animator[] animator;
    [SerializeField] private BoxCollider2D[] doorCollision;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = doors.GetComponentsInChildren<Animator>();
        doorCollision = doors.GetComponentsInChildren<BoxCollider2D>();
        Open();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown("m"))
        {
            if (isOpen)
            {
                Close();

            }
            else if (!isOpen)
            {
                Open();
            }
        } 
    }
    public void Close()
    {
        
        //doors.SetActive(true);
        isOpen = false;
        for (int i = 0; i < animator.Length; i++)
        {
            animator[i].SetBool("DoorLocked", true);
        }
        for (int i = 0;i < doorCollision.Length; i++)
        {
            doorCollision[i].enabled = true;
        }
        
        

    }

    public void Open()
    {
        
        //doors.SetActive(false);
        isOpen = true;

        for (int i = 0; i < animator.Length; i++)
        {
            animator[i].SetBool("DoorLocked", false);
        }
        for (int i = 0; i < doorCollision.Length; i++)
        {
            doorCollision[i].enabled = false;
        }
        
        

    }
}
