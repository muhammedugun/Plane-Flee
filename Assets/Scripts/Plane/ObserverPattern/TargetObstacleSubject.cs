using System;
namespace Assets.Scripts.Plane.ObserverPattern
{
    public class TargetObstacleSubject : TargetObjectSubject
    {
        public override Action GetOnTargetObjectPos => OnTargetObjectPos;

        public static event Action OnTargetObjectPos;
    }
}