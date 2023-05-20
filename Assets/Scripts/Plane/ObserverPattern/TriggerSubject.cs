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
                OnTriggerEnter.Invoke();
            }
        }

    }
}