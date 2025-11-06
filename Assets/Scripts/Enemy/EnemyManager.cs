using SplatterSystem;
using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Variables

    [Header("Splatter")]
    public MeshSplatterManager splatter;
    public SplatterSettings SplatterSettings;
    public Color splatterColour = Color.red;
    public float splatOffset = 0f;

    [Header("Enemy Variables")]
    [SerializeField] private float eHealth = 100f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pBullet")
        {
            Debug.Log("HIT");

            if (eHealth > 0)
            {
                eHealth -= 25f;               
            }
            else if (eHealth <= 0)
            {
                Destroy(gameObject);
                splatter.Spawn(SplatterSettings, transform.position, null, splatterColour);
            }

            // Take Damage

            // IF health = 0 THEN enemyDeath()

            // Splatter blood


        }
    }

    private void EnemyDamage()
    {

    }

    private void EnemyDeath()
    {
        // Enemy dies

        // Splatter more blood
    }

    public void SplatterHit(Vector2 direction)
    {
        Vector2 hitPos = (Vector2)transform.position + splatOffset * direction;
        splatter.Spawn(SplatterSettings, hitPos, direction, splatterColour);
    }
   
}
