using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Spawn.ObserverPattern;
using Assets.Scripts.Spawn;

namespace Assets.Scripts.SeasonLoop.ObserverPattern
{
    public class SeasonLoopObserverManager : AbstractObserverManager
    {
        SeasonLoopManager seasonLoopManager;

        private void Awake()
        {
            seasonLoopManager = GetComponent<SeasonLoopManager>();
        }

        private void Start()
        {
            SubscribeToEvents();
        }

        private void OnDisable()
        {
            UnsubscribeToEvents();
        }


        public override void SubscribeToEvents()
        {
            LoopTimeSubject.OnLoopTimeReached += seasonLoopManager.SetNextLoopTime;
            
            foreach(var seasonLoop in seasonLoopManager.seasonLoops)
            {
                LoopTimeSubject.OnLoopTimeReached += seasonLoop.ResetSpriteCount;
                LoopTimeSubject.OnLoopTimeReached += seasonLoop.ChangeSeason;
                if(seasonLoop as GroundSeasonLoop)
                    GroundSpawner.OnSpawnDone += seasonLoop.ChangeSprite;
                else if(seasonLoop as ObstacleSeasonLoop)
                {
                    UnityEngine.Debug.Log("Çalıştı");
                    ObstacleSpawner.OnSpawnDone += seasonLoop.ChangeSprite;
                    
                }
                    
            }

        }

        public override void UnsubscribeToEvents()
        {
            LoopTimeSubject.OnLoopTimeReached -= seasonLoopManager.SetNextLoopTime;

            foreach (var seasonLoop in seasonLoopManager.seasonLoops)
            {
                LoopTimeSubject.OnLoopTimeReached -= seasonLoop.ResetSpriteCount;
                LoopTimeSubject.OnLoopTimeReached -= seasonLoop.ChangeSeason;
                if (seasonLoop as GroundSeasonLoop)
                    GroundSpawner.OnSpawnDone -= seasonLoop.ChangeSprite;
                else if (seasonLoop as ObstacleSeasonLoop)
                    ObstacleSpawner.OnSpawnDone -= seasonLoop.ChangeSprite;
            }
        }
    }
}