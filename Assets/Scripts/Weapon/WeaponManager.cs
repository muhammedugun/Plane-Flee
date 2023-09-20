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

        private bool isFirstLaunch = true;
        private GameObject rocket, bullet;
        private Rocket rocketScript;
        private int weaponNo = 0; // 0 = bullet, 1 = rocket
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
            if (weaponNo == 0)
            {
                weaponNo = 1;
                changeWeaponButton.sprite = rocketSprite;
            }
            else
            {
                weaponNo = 0;
                changeWeaponButton.sprite = bulletSprite;
            }

        }

        public void WeaponLauncher()
        {
            if (weaponNo == 0)
            {
                LaunchBullet();
            }
            else
            {
                LaunchRocket();
            }

        }


        void LaunchRocket()
        {
            if (!isFirstLaunch && Time.time > rocketScript.nextReloadTime)
            {
                rocketScript.nextReloadTime = Time.time + rocketScript.reloadTime;
                rocket.transform.SetPositionAndRotation(planeTransform.position, planeTransform.rotation);
                rocketScript.Continue();
            }
            else if (isFirstLaunch)
            {
                rocket = Instantiate(rocketPrefab, position: planeTransform.position, rotation: planeTransform.rotation);
                rocketScript = rocket.GetComponent<Rocket>();
                isFirstLaunch = false;
                rocketScript.nextReloadTime = Time.time + rocketScript.reloadTime;
            }
        }

        

        void LaunchBullet()
        {
            if (bulletArray[29] == null && Time.time > bulletNextReloadTime)
            {
                bullet = Instantiate(bulletPrefab, position: planeTransform.position, rotation: planeTransform.rotation);
                bulletArray[bulletCount] = bullet;
                bulletCount++;
                bulletNextReloadTime = Time.time + Bullet.reloadTime;
                bullet.GetComponent<Bullet>().Continue();
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