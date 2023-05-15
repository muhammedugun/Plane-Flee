using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Spawn;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverPattern
{
    /// <summary>
    /// Uçağın gözlenen durumu (Observer design pattern) ile ilgili görevleri yönetmekten sorumlu
    /// </summary>
    public class PlaneSubjectManager : AbstractSubjectManager
    {
        [Tooltip("Objeler arasındaki mevcut olan ConsecutiveGroundSpawner'i atınız")]
        [SerializeField] GroundSpawner groundSpawner;
        [Tooltip("Objeler arasındaki mevcut olan IntermittentObstacleSpawner'i atınız")]
        [SerializeField] ObstacleSpawner obstacleSpawner;

        TargetObjectSubject targetGroundSubject;
        TargetObjectSubject targetObstacleSubject;

        private void Awake()
        {

            targetGroundSubject = GetComponent<TargetGroundSubject>();
            targetObstacleSubject = GetComponent<TargetObstacleSubject>();
        }

        private void LateUpdate()
        {
            NotifyTargetObject(groundSpawner, targetGroundSubject, groundSpawner.spawnObjects.Length - 2);
            NotifyTargetObject(obstacleSpawner, targetObstacleSubject, obstacleSpawner.spawnObjects.Length -4);
        }

        void NotifyTargetObject(AbstractSpawner abstractSpawner, TargetObjectSubject targetObjectSubject, int targetObjectIndex)
        {
            var targetObjectPos = abstractSpawner.spawnObjects[targetObjectIndex].transform.position;
            targetObjectSubject.TargetObjectPosNotify(targetObjectPos);
        }

    }
}