using System;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverPattern
{
    public class TriggerSubject : MonoBehaviour
    {
        public static event Action OnTriggerEnter;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("ground"))
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
}