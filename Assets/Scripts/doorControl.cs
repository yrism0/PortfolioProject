using TopDown.Movement;
using UnityEngine;

public class doorControl : MonoBehaviour
{

    public GameObject doors;
   public  bool isopen;
    public bool isclose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doors.SetActive(true);
        isclose = true;
        isopen = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown("m"))
        {
            if (isclose == false)
            {
                close();

            }
            else if (isopen == false)
            {
                open();
            }
        }
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
