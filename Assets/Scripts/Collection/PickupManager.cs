using Assets.Scripts.Collection;
using Assets.Scripts.Plane.ObserverPattern;
using System;
using UnityEngine;

public class PickupManager : MonoBehaviour
{

    public float respawnTime;
    public CoinDisplay coinDisplay;
    public GameObject plane, coinMultiplierIcon, shield, pickup;
    public int type; // 0=score, 1=shield
    private float startTime;

    [Obsolete]
    private void Start()
    {
        type = UnityEngine.Random.RandomRange(0, 2);

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
        if (startTime != 0f && type == 0 && Time.time >= startTime + respawnTime)
        {
            coinDisplay.isScoreMultiplierActive = false;
            coinMultiplierIcon.SetActive(false);
            startTime = 0;
            Invoke(nameof(Respawn), respawnTime);
        }
    }

    [System.Obsolete]
    private void Respawn()
    {
        type = UnityEngine.Random.RandomRange(0, 2);

        pickup.SetActive(true);
        pickup.GetComponent<PickupMovement>().xpos = plane.transform.position.x + 100f;
    }

    private void PickupController()
    {
        pickup.SetActive(false);
        // skor ise
        if (type == 0)
        {
            startTime = Time.time;
            coinMultiplierIcon.SetActive(true);
            coinDisplay.isScoreMultiplierActive = true;
        }
        // shield ise
        else if (type == 1)
        {
            shield.SetActive(true);
            shield.GetComponent<SpriteRenderer>().enabled = true;
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