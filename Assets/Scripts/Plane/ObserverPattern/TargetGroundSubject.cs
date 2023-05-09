using Assets.Scripts.Spawn;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverDesign
{
    /// <summary>
    /// Uçağın hedef zemine varması ile ilgili bildirimde bulunma görevlerinden sorumlu
    /// </summary>
    public class TargetGroundSubject : MonoBehaviour, IPositionSubject
    {
        /// <summary>
        /// Uçak hedef zemine vardı bildirimi
        /// </summary>
        public static event Action OnTargetObjectPos;

        public Transform planePosition;


        public void TargetObjectPosNotify()
        {

            if((Vector2)ConsecutiveGroundSpawner.finalGroundPosition.position!=Vector2.zero)
            {
                if (planePosition.position.x >= ConsecutiveGroundSpawner.finalGroundPosition.position.x) OnTargetObjectPos?.Invoke();
            }
            
        }

    }
}