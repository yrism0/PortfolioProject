using UnityEngine;

namespace TopDown.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [Header("Movement Stats")]
        [SerializeField] private float speed;
        [SerializeField] private float lifetime;
        private Rigidbody2D body;
        private float lifeTimer;

        [Header("Bullet FX")]
        [SerializeField] private GameObject impactEffect;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        public void ShootBullet(Transform shootPoint)
        {
            lifeTimer = 0;
            body.linearVelocity = Vector2.zero;
            transform.position = shootPoint.position;
            transform.position = shootPoint.position;
            gameObject.SetActive(true);
            
            body.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }

        private void Update()
        {
            lifeTimer += Time.deltaTime;
            if (lifeTimer >= lifetime)
                Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Player")
            {
                Instantiate(impactEffect, transform.transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Player")
            {
                Instantiate(impactEffect, transform.transform.position, transform.rotation);
                Destroy(gameObject);
                PlayerHealth.instance.TakeDamage(5);
                // Damage Player
            }
        }
    }

} 
