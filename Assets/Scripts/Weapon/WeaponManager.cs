using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform planeTransform;
    public GameObject rocketPrefab, bulletPrefab;
    public Image changeWeaponButton;
    public Sprite bulletSprite, rocketSprite;
    private bool isfirstLaunch=true;
    private GameObject rocket, bullet;
    private Rocket rocketScript;
    private int weaponNo=0; // 0 = bullet, 1 = rocket
    private bool isButtonPressed = false;
    


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
        if(weaponNo==0)
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
        if (!isfirstLaunch && Time.time > rocketScript.nextReloadTime)
        {
            rocketScript.nextReloadTime = Time.time + rocketScript.reloadTime;
            rocket.transform.SetPositionAndRotation(planeTransform.position, planeTransform.rotation);
            rocketScript.Continue();
        }
        else if (isfirstLaunch)
        {
            rocket = Instantiate(rocketPrefab, position: planeTransform.position, rotation: planeTransform.rotation);
            rocketScript = rocket.GetComponent<Rocket>();
            isfirstLaunch = false;
            rocketScript.nextReloadTime = Time.time + rocketScript.reloadTime;
        }
    }

    GameObject[] bulletArray = new GameObject[30];
    int bulletCount=0;

    void LaunchBullet()
    {
        if(bulletArray[29]==null && Time.time > Bullet.nextReloadTime)
        {
            bullet = Instantiate(bulletPrefab, position: planeTransform.position, rotation: planeTransform.rotation);
            bulletArray[bulletCount] = bullet;
            bulletCount++;
            Bullet.nextReloadTime = Time.time + Bullet.reloadTime;
            bullet.GetComponent<Bullet>().Continue();
        }

        else if(bulletArray[29] != null && Time.time > Bullet.nextReloadTime)
        {
            if(bulletCount>=29)
            {
                bulletCount = 0;
            }

            Bullet.nextReloadTime = Time.time + Bullet.reloadTime;

            bulletArray[bulletCount].transform.SetPositionAndRotation(planeTransform.position, planeTransform.rotation);
            bulletArray[bulletCount].GetComponent<Bullet>().Continue();
            bulletCount++;
        }
    }


    private void Update()
    {
        if(isButtonPressed)
        {
            WeaponLauncher();
        }
    }



}
