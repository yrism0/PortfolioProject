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

        [Header("Forms")]
        private bool ChangingForm;
        [SerializeField] private bool defaultState;
        [SerializeField] private Animator playerAnimator;


        // Shoot Point

        private void Start()
        {
            defaultState = true;
            playerAnimator.SetBool("IsDefault", true);
        }

        private void Update()
        {
            cooldownTimer += Time.deltaTime;

            // TEST CODE 
            if (Input.GetKeyDown(KeyCode.P))
            {
                ChangeForm();
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                ReturnToDefaultState();
            }
        }

        private void Shoot()
        {
            if (defaultState)
            {
                if (cooldownTimer < cooldown) return;

                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation, null);
                bullet.GetComponent<Projectile>().ShootBullet(firepoint);

                muzzleFlashAnimator.SetTrigger("shoot");
                cooldownTimer = 0;
            }
            else if (!defaultState)
            {
                
            }
            
        }

        private void ChangeForm()
        {
            if (!ChangingForm)
            {
                ChangingForm = true;
                // ChangingForm set to FALSE in Animation Flag
                defaultState = false;
                playerAnimator.SetBool("IsDefault", false);
                
            }

        }

        private void ReturnToDefaultState()
        {
            if (!ChangingForm)
            {
                ChangingForm = true;
                // ChangingForm set to FALSE in Animation Flag
                defaultState = true;
                playerAnimator.SetBool("IsDefault", true);
            }
            

        }

        private void ChangingFormAnimFlag()
        {
            // Called via Animation Flag
            ChangingForm = false;
        }
        #region Input

        private void OnShoot()
        {
            Shoot();
        }

        #endregion
    }
}
