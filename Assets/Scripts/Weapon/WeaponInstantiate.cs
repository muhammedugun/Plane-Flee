using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponInstantiate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform planeTransform;
    public GameObject rocketPrefab, bulletPrefab;
    private bool isfirstLaunch=true;
    private GameObject rocket, bullet;
    Rocket rocketScript;
    Bullet? bulletScript;

    private bool isButtonPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonPressed = false;
    }

    public void WeaponLauncher()
    {

        LaunchBullet();

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
        if(bulletScript == null)
        {
            bullet = Instantiate(bulletPrefab, position: planeTransform.position, rotation: planeTransform.rotation);
            bulletArray[bulletCount] = bullet;
            bulletCount++;
            bulletScript = bullet.GetComponent<Bullet>();
        }

        else if(bulletArray[29]==null && Time.time > bulletScript.nextReloadTime)
        {
            bullet = Instantiate(bulletPrefab, position: planeTransform.position, rotation: planeTransform.rotation);
            bulletArray[bulletCount] = bullet;
            bulletCount++;
            bulletScript.nextReloadTime = Time.time + bulletScript.reloadTime;
            bulletScript.Continue(bullet);
        }

        else if(bulletArray[29] != null && Time.time > bulletScript.nextReloadTime)
        {
            if(bulletCount>=29)
            {
                bulletCount = 0;
            }
            
            bulletScript.nextReloadTime = Time.time + bulletScript.reloadTime;

            bulletArray[bulletCount].transform.SetPositionAndRotation(planeTransform.position, planeTransform.rotation);
            bulletScript.Continue(bulletArray[bulletCount]);
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
