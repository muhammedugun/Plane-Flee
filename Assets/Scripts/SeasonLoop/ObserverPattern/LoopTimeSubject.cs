using System;
using UnityEngine;

namespace Assets.Scripts.Spawn.ObserverPattern
{
    /// <summary>
    /// Döngü zamanı ile ilgili bildirimlerde bulunma görevlerinden sorumlu
    /// </summary>
    public class LoopTimeSubject : MonoBehaviour
    {

        /// <summary>
        /// Döngü zamanına varıldı
        /// </summary>
        public static event Action OnLoopTimeReached;


        /// <summary>
        /// Döngü zamanına varıldıysa bildirir
        /// </summary>
        /// <param name="nextLoopTime"></param>
        public static void LoopTimeReachedNotify(float nextLoopTime)
        {
            if (Time.time >= nextLoopTime)
            {
                Debug.Log("Time: " +  Time.time);
                OnLoopTimeReached.Invoke();
            }
        }

    }
}