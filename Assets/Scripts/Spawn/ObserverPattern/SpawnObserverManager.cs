using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Plane.ObserverPattern;

namespace Assets.Scripts.Spawn.ObserverPattern
{
    /// <summary>
    /// Spawn sisteminin gözlemcilik (Observer Desing Pattern) ile ilgili görevlerini yönetmekten sorumlu
    /// </summary>
    public class SpawnObserverManager : AbstractObserverManager
    {
        ConsecutiveGroundSpawner consecutiveGroundSpawner;
        SeasonLoop seasonLoop;

        private void Awake()
        {
            consecutiveGroundSpawner = GetComponent<ConsecutiveGroundSpawner>();
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

            LoopTimeSubject.OnLoopTimeReached += seasonLoop.SetNextLoopTime;
            LoopTimeSubject.OnLoopTimeReached += seasonLoop.SetCurrentGroundSpriteIndex;
            LoopTimeSubject.OnLoopTimeReached += seasonLoop.ChangeGroundSprite;

            ConsecutiveGroundSpawner.OnSpawnDone += seasonLoop.ChangeGroundSprite;

        }

        public override void UnsubscribeToEvents()
        {
            TargetGroundSubject.OnTargetObjectPos -= consecutiveGroundSpawner.SpawnContinuously;
        }

        
    }
}