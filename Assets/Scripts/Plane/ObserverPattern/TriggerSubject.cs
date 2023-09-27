using System;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverPattern
{
    public class TriggerSubject : MonoBehaviour
    {
        public static event Action OnTriggerEnter;
        public static event Action OnTriggerWithShield; // üzerinde kalkan varken bir engele çarptı
        public PickupManager pickupManager;
        [SerializeField] private GameObject shield;

        [Obsolete]
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("ground"))
            {
                if(shield.active == false)
                {
                    if (!PlayerPrefs.HasKey("GameOverCount"))
                    {
                        PlayerPrefs.SetInt("GameOverCount", 0);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("GameOverCount", PlayerPrefs.GetInt("GameOverCount") + 1);
                    }
                    Debug.Log(collision.gameObject.name);
                    OnTriggerEnter.Invoke();
                }
            }
        }
        
        [Obsolete]
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("ground"))
            {
                if (shield.active == true && shield.GetComponent<SpriteRenderer>().enabled)
                {
                    OnTriggerWithShield.Invoke();
                }
                    
            }
        }

        public void DeactiveShield()
        {

            shield.SetActive(false);
            pickupManager.InvokeRespawn();
        }

    }
}