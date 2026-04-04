using UnityEngine;
using UnityEngine.SceneManagement;

public class EEInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject InstantiatePrefab;
    [SerializeField] private GameObject player;
    

    public void InstantiateExplosion()
    {
        Instantiate(InstantiatePrefab, player.transform.position, Quaternion.identity);
    }

    public void StartEnd()
    {
        SceneManager.LoadScene("EndScene");
    }
}
