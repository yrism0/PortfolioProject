using UnityEngine;

namespace TopDown.Shooting
{
    public class GunController : MonoBehaviour
    {
        [Header("Cooldown")]
        [SerializeField] private float cooldown = 0.25f;
        private float cooldownTimer;

        [Header("References")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firepoint;
        [SerializeField] private Animator muzzleFlashAnimator;

        [Header("Sniper Form References")]
        [SerializeField] private Animator muzzleFlashAnimatorS;
        [SerializeField] private Transform sFirepoint;
        [SerializeField] private GameObject sBulletPrefab;

        [Header("Forms")]
        public static bool changingForm;
        private bool buttonPressed;
        [SerializeField] private bool defaultState;
        [SerializeField] public Animator playerAnimator;
        private float sniperCountdown;

        
        


        // Shoot Point

        private void Start()
        {
            defaultState = true;
            playerAnimator.SetBool("IsDefault", true);
        }

        private void Update()
        {
            cooldownTimer += Time.deltaTime;
            sniperCountdown += Time.deltaTime;

            // TEST CODE 
            if (Input.GetKeyDown(KeyCode.P) && !changingForm && defaultState)
            {
                SniperForm();
            }
            else if (Input.GetKeyDown(KeyCode.L) && !changingForm && !defaultState)
            {                
                ReturnToDefaultState();
            }

            //SniperForm();
        }

        private void Shoot()
        {
            if (defaultState && UIManager.Instance.isPaused == false && !PlayerHealth.instance.isPlayerDead)
            {
                if (cooldownTimer < cooldown) return;

                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation, null);
                bullet.GetComponent<Projectile>().ShootBullet(firepoint);

                muzzleFlashAnimator.SetTrigger("shoot");
                cooldownTimer = 0;
            }
            else if (!defaultState && UIManager.Instance.isPaused == false && !PlayerHealth.instance.isPlayerDead)
            {
                //GameObject sBullet = Instantiate(sBulletPrefab, sFirepoint.position, sFirepoint.rotation, null);
                //sBullet.GetComponent<Projectile>().ShootBullet(sFirepoint);

                if (cooldownTimer < cooldown) return;

                GameObject bullet = Instantiate(sBulletPrefab, sFirepoint.position, sFirepoint.rotation, null);
                bullet.GetComponent<Projectile>().ShootBullet(sFirepoint);

                muzzleFlashAnimatorS.SetTrigger("shoot");
                cooldownTimer = 0;
            }
            
        }

        private void ChangeForm()
        {
            
            if (!changingForm)
            {
                changingForm = true;
                // ChangingForm set to FALSE in Animation Flag
                defaultState = false;
                playerAnimator.SetBool("IsDefault", false);

            }

        }

        private void ReturnToDefaultState()
        {
            
            if (!changingForm)
            {
                changingForm = true;
                // ChangingForm set to FALSE in Animation Flag
                defaultState = true;
                playerAnimator.SetBool("IsDefault", true);

            }
            

        }

        private void SniperForm()
        {
            ChangeForm();
            if (!defaultState)
            {
                sniperCountdown = 0;
                if (sniperCountdown >= 5)
                {
                    ReturnToDefaultState();
                    
                }
            }
            
        }
        
        #region Input

        private void OnShoot()
        {
            Shoot();
        }

        #endregion
    }
}
