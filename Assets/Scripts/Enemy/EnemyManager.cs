using SplatterSystem;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Variables

    [Header("Splatter")]
    public MeshSplatterManager splatter;
    public SplatterSettings SplatterSettings;
    public Color deathSplatterColor = Color.red;

    [Header("Enemy Variables")]
    private float eHealth = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void EnemyDeath()
    {

    }
   
}
