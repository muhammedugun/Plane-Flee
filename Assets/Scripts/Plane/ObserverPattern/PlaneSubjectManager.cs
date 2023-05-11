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
        [SerializeField] ConsecutiveGroundSpawner consecutiveGroundSpawner;
        TargetObjectSubject targetGroundSubject;

        private void Awake()
        {
            targetGroundSubject = GetComponent<TargetGroundSubject>();
        }

        private void LateUpdate()
        {
            var targetObjectPos = consecutiveGroundSpawner.spawnObjects[consecutiveGroundSpawner.spawnObjects.Length - 2].transform.position;
            targetGroundSubject.TargetObjectPosNotify(targetObjectPos);
        }

    }
}