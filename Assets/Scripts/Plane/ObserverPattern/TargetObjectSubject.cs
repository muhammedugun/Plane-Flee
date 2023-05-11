using System;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverPattern
{
    /// <summary>
    /// Uçağın hedef objeye varması ile ilgili bildirimde bulunma görevlerinden sorumlu
    /// </summary>
    public abstract class TargetObjectSubject : MonoBehaviour
    {
        public abstract Action GetOnTargetObjectPos { get; }
        public Transform planePosition;


        public virtual void TargetObjectPosNotify(Vector2 targetObjectPosition)
        {

            if(targetObjectPosition!= Vector2.zero)
            {
                if (planePosition.position.x >= targetObjectPosition.x) GetOnTargetObjectPos?.Invoke();
            }
            
        }

    }
}