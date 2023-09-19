using Assets.Scripts.Collection;
using Assets.Scripts.Plane.ObserverPattern;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public float respawnTime;
    public ScoreDisplay scoreDisplay;
    public GameObject plane, scoreMultiplierIcon, shield, pickup;
    public int type; // 0=score, 1=shield
    private float startTime;

    [System.Obsolete]
    private void Start()
    {        
        type = Random.RandomRange(0, 2);
        Debug.Log("randomrange" + type);

        CollectionManager.OnCollectPickup += PickupController;
        TriggerSubject.OnTriggerWithShield += DeactiveShieldSprite;

        startTime = 0f;

    }

    private void OnDisable()
    {
        CollectionManager.OnCollectPickup -= PickupController;
        TriggerSubject.OnTriggerWithShield -= DeactiveShieldSprite;
    }

    private void LateUpdate()
    {

        if (startTime!=0f && type==0 && Time.time >= startTime + respawnTime)
        {
            scoreDisplay.isScoreMultiplierActive = false;
            scoreMultiplierIcon.SetActive(false);
            startTime = 0;
            Invoke(nameof(Respawn), respawnTime);
        }
    }

    [System.Obsolete]
    private void Respawn()
    {

        type = Random.RandomRange(0, 2);
        Debug.Log("randomrange" + type);

        pickup.SetActive(true);
        pickup.GetComponent<PickupMovement>().xpos = plane.transform.position.x + 10f;
       

    }

    private void PickupController()
    {
        pickup.SetActive(false);
        // skor ise
        if (type==0)
        {
            startTime = Time.time;
            scoreMultiplierIcon.SetActive(true);
            scoreDisplay.isScoreMultiplierActive = true;
        }
        // shield ise
        else if(type==1)
        {
            shield.SetActive(true);
        }
    }


    public void DeactiveShieldSprite()
    {
        shield.GetComponent<SpriteRenderer>().enabled = false;
        plane.GetComponent<Animator>().SetTrigger("ghost");
    }


    public void InvokeRespawn()
    {
        Invoke(nameof(Respawn), respawnTime);
    }
}


