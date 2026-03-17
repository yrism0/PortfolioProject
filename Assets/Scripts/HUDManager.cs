using UnityEngine;

public class HUDManager : MonoBehaviour
{

    [SerializeField] private GameObject miniMap;
    [SerializeField] private bool mapOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mapOpen)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OpenMap();
                
            }
        }
        else if (mapOpen)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                CloseMap();
            }
        }
        else
        {
            return;
        }
    }

    private void OpenMap()
    {
        mapOpen = true;
        miniMap.SetActive(true);

    }

    private void CloseMap()
    {
        mapOpen = false;
        miniMap.SetActive(false);
    }
}
