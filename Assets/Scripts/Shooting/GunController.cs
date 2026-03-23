using System.Collections;
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
        private float sniperTimer;
        private float shotsLeft;
        

        [Header("Forms")]
        public static bool changingForm;
        private bool buttonPressed;
        [SerializeField] private bool defaultState;
        [SerializeField] public Animator playerAnimator;
        private float sniperCountdown;
        private bool onCooldown;
         
        private Color defaultEnergy = new Color32(0, 255, 249, 255);





        // Shoot Point

        private void Start()
        {
            defaultState = true;
            playerAnimator.SetBool("IsDefault", true);
            sniperTimer = 5;
            sniperCountdown = 5;
            shotsLeft = 3;
            onCooldown = false;
        }

        private void Update()
        {
            cooldownTimer += Time.deltaTime;
            
            UpdateAmmoUI();
            CheckForm();
            
            

            // TEST CODE 
            if (Input.GetKeyDown(KeyCode.Mouse1) && !changingForm && defaultState && !onCooldown)
            {
                SniperForm();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1) && onCooldown)
            {
                StartCoroutine(EnergyCooldown());
            }
            /*else if (Input.GetKeyDown(KeyCode.L) && !changingForm && !defaultState)
            {                
                ReturnToDefaultState();
            }*/

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
                shotsLeft--;

                muzzleFlashAnimatorS.SetTrigger("shoot");
                cooldownTimer = 0;
            }
            
        }

        private void ChangeForm()
        {
            
            if (!changingForm)
            {
                UIManager.Instance.ShowAmmoUI();
                shotsLeft = 3;
                changingForm = true;
                // ChangingForm set to FALSE in Animation Flag
                defaultState = false;
                playerAnimator.SetBool("IsDefault", false);

            }

        }

        private void ReturnToDefaultState()
        {
            //Debug.Log("Check1");
            if (!changingForm)
            {
                sniperCountdown = 0;
                onCooldown = true;
                UIManager.Instance.HideAmmoUI();
                //Debug.Log("Check2");
                changingForm = true;
                // ChangingForm set to FALSE in Animation Flag
                defaultState = true;
                playerAnimator.SetBool("IsDefault", true);

            }
            

        }

        private void SniperForm()
        {
            ChangeForm();       
        }

        private void CheckForm()
        {
            if (!defaultState)
            {
                
                sniperTimer -= Time.deltaTime;
                if (sniperTimer <= 0 || shotsLeft == 0)
                {
                    
                    ReturnToDefaultState ();
                    sniperTimer = 5;
                    //Debug.Log("Check0");
                }
            }
            if (onCooldown)
            {
                sniperCountdown += Time.deltaTime;
                if (sniperCountdown >= 5)
                {
                    onCooldown = false;
                    
                }
            }


        }

        IEnumerator EnergyCooldown()
        {
            UIManager.Instance.cooldownFill.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            UIManager.Instance.cooldownFill.color = defaultEnergy;
        }

        private void UpdateAmmoUI()
        {
            UIManager.Instance.timerSlider.value = sniperTimer;
            UIManager.Instance.shotSlider.value = shotsLeft;
            UIManager.Instance.cooldownSlider.value = sniperCountdown;
        }
        
        #region Input

        private void OnShoot()
        {
            Shoot();
        }

        #endregion
    }
}
