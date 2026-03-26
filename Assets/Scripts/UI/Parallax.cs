using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer bg;

    private void Update()
    {
        bg.material.mainTextureOffset += new Vector2(speed*Time.deltaTime, 0);
    }

}