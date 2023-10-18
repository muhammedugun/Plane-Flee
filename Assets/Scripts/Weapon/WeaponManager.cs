using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Weapon
{
    public class WeaponManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Transform planeTransform;
        public GameObject rocketPrefab, bulletPrefab;
        public Image changeWeaponButton;
        public Sprite bulletSprite, rocketSprite;

        [SerializeField] private UIWeaponManager uIWeaponManager;

        private bool isFirstLaunch = true;
        private GameObject rocket, bullet;
        private Rocket rocketScript;
        /// <summary>
        /// Bullet = 0, Rocket = 1
        /// </summary>
        internal int weaponNo = 0;
        private bool isButtonPressed = false;
        private readonly GameObject[] bulletArray = new GameObject[30];
        private int bulletCount = 0;
        private static float bulletNextReloadTime=0;


        public void OnPointerDown(PointerEventData eventData)
        {
            isButtonPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isButtonPressed = false;
        }

        public void ChangeWeapon()
        {
            switch (weaponNo)
            {
                case 0:
                    weaponNo = 1;
                    uIWeaponManager.UpdateChangeWeaponText();
                    changeWeaponButton.sprite = rocketSprite;
                    
                    break;

                case 1:
                    weaponNo = 0;
                    uIWeaponManager.UpdateChangeWeaponText();
                    changeWeaponButton.sprite = bulletSprite;
                   
                    break;

                default:
                    break;
            }
        }
        public void WeaponLauncher()
        {
            switch (weaponNo)
            {
                case 0:
                    LaunchBullet();
                    break;

                case 1:
                    LaunchRocket();
                    break;

                default:
                    break;
            }
        }


        void LaunchRocket()
        {
            if(PlayerPrefs.GetInt("rocketCount") > 0)
            {
                if (!isFirstLaunch && Time.time > rocketScript.nextReloadTime)
                {
                    rocketScript.nextReloadTime = Time.time + rocketScript.reloadTime;
                    rocket.transform.SetPositionAndRotation(planeTransform.position, planeTransform.rotation);
                    rocketScript.Continue();
                    PlayerPrefs.SetInt("rocketCount", PlayerPrefs.GetInt("rocketCount") - 1);
                    uIWeaponManager.UpdateChangeWeaponText();
                }
                else if (isFirstLaunch)
                {
                    rocket = Instantiate(rocketPrefab, position: planeTransform.position, rotation: planeTransform.rotation);
                    rocketScript = rocket.GetComponent<Rocket>();
                    isFirstLaunch = false;
                    rocketScript.nextReloadTime = Time.time + rocketScript.reloadTime;
                    PlayerPrefs.SetInt("rocketCount", PlayerPrefs.GetInt("rocketCount") - 1);
                    uIWeaponManager.UpdateChangeWeaponText();
                }
            }
        }

        

        void LaunchBullet()
        {
            if(PlayerPrefs.GetInt("bulletCount") > 0)
            {
                if (bulletArray[29] == null && Time.time > bulletNextReloadTime)
                {
                    bullet = Instantiate(bulletPrefab, position: planeTransform.position, rotation: planeTransform.rotation);
                    bulletArray[bulletCount] = bullet;
                    bulletCount++;
                    bulletNextReloadTime = Time.time + Bullet.reloadTime;
                    bullet.GetComponent<Bullet>().Continue();
                    PlayerPrefs.SetInt("bulletCount", PlayerPrefs.GetInt("bulletCount") - 1);
                    uIWeaponManager.UpdateChangeWeaponText();
                }

                else if (bulletArray[29] != null && Time.time > bulletNextReloadTime)
                {
                    if (bulletCount >= 29)
                    {
                        bulletCount = 0;
                    }

                    bulletNextReloadTime = Time.time + Bullet.reloadTime;

                    bulletArray[bulletCount].transform.SetPositionAndRotation(planeTransform.position, planeTransform.rotation);
                    bulletArray[bulletCount].GetComponent<Bullet>().Continue();
                    bulletCount++;
                    PlayerPrefs.SetInt("bulletCount", PlayerPrefs.GetInt("bulletCount") - 1);
                    uIWeaponManager.UpdateChangeWeaponText();
                }
            }
        }


        private void Update()
        {
            if (isButtonPressed)
            {
                WeaponLauncher();
            }
        }



    }
}