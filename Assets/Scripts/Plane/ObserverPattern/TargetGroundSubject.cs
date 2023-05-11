using System;

namespace Assets.Scripts.Plane.ObserverPattern
{
    /// <summary>
    /// Uçağın hedef zemine varması ile ilgili bildirimde bulunma görevlerinden sorumlu
    /// </summary>
    public class TargetGroundSubject : TargetObjectSubject
    {
        public override Action GetOnTargetObjectPos => OnTargetObjectPos;

        public static event Action OnTargetObjectPos;


    }
}