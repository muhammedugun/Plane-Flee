using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Plane.ObserverPattern;

namespace Assets.Scripts.Spawn.ObserverPattern
{
    /// <summary>
    /// Spawn sisteminin gözlemcilik (Observer Desing Pattern) ile ilgili görevlerini yönetmekten sorumlu
    /// </summary>
    public class SpawnObserverManager : AbstractObserverManager
    {
        AbstractSpawner consecutiveGroundSpawner;
        AbstractSpawner intermittentObstacleSpawner;
        SeasonLoop seasonLoop;

        private void Awake()
        {
            consecutiveGroundSpawner = GetComponent<GroundSpawner>();
            intermittentObstacleSpawner = GetComponent<ObstacleSpawner>();
            seasonLoop = GetComponent<SeasonLoop>();

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
            
            TargetGroundSubject.OnTargetObjectPos += consecutiveGroundSpawner.SpawnContinuously;
            TargetObstacleSubject.OnTargetObjectPos += intermittentObstacleSpawner.SpawnContinuously;

            LoopTimeSubject.OnLoopTimeReached += seasonLoop.SetNextLoopTime;

            LoopTimeSubject.OnLoopTimeReached += seasonLoop.SetCurrentGroundSpriteIndex;
            LoopTimeSubject.OnLoopTimeReached += seasonLoop.ChangeGroundSprite;

            LoopTimeSubject.OnLoopTimeReached += seasonLoop.SetCurrentObstacleSpriteIndex;
            LoopTimeSubject.OnLoopTimeReached += seasonLoop.ChangeObstacleSprite;

            GroundSpawner.OnSpawnDone += seasonLoop.ChangeGroundSprite;
            ObstacleSpawner.OnSpawnDone += seasonLoop.ChangeObstacleSprite;

        }

        public override void UnsubscribeToEvents()
        {
            TargetGroundSubject.OnTargetObjectPos -= consecutiveGroundSpawner.SpawnContinuously;
            TargetObstacleSubject.OnTargetObjectPos -= intermittentObstacleSpawner.SpawnContinuously;

            LoopTimeSubject.OnLoopTimeReached -= seasonLoop.SetNextLoopTime;

            LoopTimeSubject.OnLoopTimeReached -= seasonLoop.SetCurrentGroundSpriteIndex;
            LoopTimeSubject.OnLoopTimeReached -= seasonLoop.ChangeGroundSprite;

            LoopTimeSubject.OnLoopTimeReached -= seasonLoop.SetCurrentObstacleSpriteIndex;
            LoopTimeSubject.OnLoopTimeReached -= seasonLoop.ChangeObstacleSprite;

            GroundSpawner.OnSpawnDone -= seasonLoop.ChangeGroundSprite;

            ObstacleSpawner.OnSpawnDone -= seasonLoop.ChangeObstacleSprite;
        }


    }
}