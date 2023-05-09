using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Plane.ObserverDesign;
using UnityEngine;

namespace Assets.Scripts.Spawn.ObserverDesign
{
    /// <summary>
    /// Spawn sisteminin gözlemcilik (Observer Desing Pattern) ile ilgili görevleri yönetmekten sorumlu
    /// </summary>
    public class SpawnObserverManager : MonoBehaviour, IObserverManager
    {
        ConsecutiveGroundSpawner consecutiveGroundSpawner;

        private void Start()
        {
            consecutiveGroundSpawner = GetComponent<ConsecutiveGroundSpawner>();
        }

        private void OnEnable()
        {
            SubscribeToEvents();
        }

        private void OnDisable()
        {
            UnsubscribeToEvents();
        }

        public void SubscribeToEvents()
        {
            TargetGroundSubject.OnTargetObjectPos += consecutiveGroundSpawner.SpawnContinuously;
        }

        public void UnsubscribeToEvents()
        {
            TargetGroundSubject.OnTargetObjectPos -= consecutiveGroundSpawner.SpawnContinuously;
        }

    }
}