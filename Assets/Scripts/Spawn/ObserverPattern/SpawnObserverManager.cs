using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Plane.ObserverPattern;

namespace Assets.Scripts.Spawn.ObserverPattern
{
    /// <summary>
    /// Spawn sisteminin gözlemcilik (Observer Desing Pattern) ile ilgili görevlerini yönetmekten sorumlu
    /// </summary>
    public class SpawnObserverManager : AbstractObserverManager
    {
        AbstractSpawner groundSpawner;
        AbstractSpawner obstacleSpawner;
        AbstractSpawner starSpawner;

        private void Awake()
        {
            groundSpawner = GetComponent<GroundSpawner>();
            obstacleSpawner = GetComponent<ObstacleSpawner>();
            starSpawner = GetComponent<StarSpawner>();
        }

        private void OnEnable()
        {
            SubscribeToEvents();
        }

        private void OnDisable()
        {
            UnsubscribeToEvents();
        }

        public override void SubscribeToEvents()
        {
            
            TargetGroundSubject.OnTargetObjectPos += groundSpawner.SpawnContinuously;
            TargetObstacleSubject.OnTargetObjectPos += obstacleSpawner.SpawnContinuously;
            ObstacleSpawner.OnSpawnDone += starSpawner.SpawnContinuously;



        }

        public override void UnsubscribeToEvents()
        {
            TargetGroundSubject.OnTargetObjectPos -= groundSpawner.SpawnContinuously;
            TargetObstacleSubject.OnTargetObjectPos -= obstacleSpawner.SpawnContinuously;
            ObstacleSpawner.OnSpawnDone -= starSpawner.SpawnContinuously;
        }


    }
}