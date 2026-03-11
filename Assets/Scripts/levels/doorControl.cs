using TopDown.Movement;
using UnityEngine;

public class doorControl : MonoBehaviour
{
    
    [SerializeField] public GameObject doors;
    [SerializeField] public  bool isopen;
    [SerializeField] public bool isclose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doors.SetActive(false);
        isclose = false;
        isopen = true;
    }

    // Update is called once per frame
    void Update()
    {
      
       /* if (Input.GetKeyDown("m"))
        {
            if (isclose == false)
            {
                close();

            }
            else if (isopen == false)
            {
                open();
            }
        } */
    }
    public void close()
    {
        Debug.Log("close");
        doors.SetActive(true);
       isopen = false;
        isclose = true;
    }

    public void open()
    {
        Debug.Log("open");
        doors.SetActive(false);
        isclose = false;
        isopen = true;
       
    }
}
