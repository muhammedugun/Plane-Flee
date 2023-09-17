using System;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverPattern
{
    public class TriggerSubject : MonoBehaviour
    {
        public static event Action OnTriggerEnter;
        public GameObject shield;
        public bool isShieldActive;
        [Obsolete]
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("ground"))
            {
                if(isShieldActive == false)
                {
                    if (!PlayerPrefs.HasKey("GameOverCount"))
                    {
                        PlayerPrefs.SetInt("GameOverCount", 0);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("GameOverCount", PlayerPrefs.GetInt("GameOverCount") + 1);
                    }

                    OnTriggerEnter.Invoke();
                }
            }
        }
        
        [Obsolete]
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("ground"))
            {
                if (shield.active == true)
                {
                    shield.SetActive(false);
                    gameObject.GetComponent<Animator>().SetTrigger("isGhost");
                }
            }
        }

        public void DeactiveShield()
        {
            isShieldActive = false;
        }

    }
}