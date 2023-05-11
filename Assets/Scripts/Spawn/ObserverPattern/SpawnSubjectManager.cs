using Assets.Scripts.ObserverPattern;

namespace Assets.Scripts.Spawn.ObserverPattern
{
    public class SpawnSubjectManager : AbstractSubjectManager
    {
        SeasonLoop seasonLoop;

        private void Awake()
        {
            seasonLoop = GetComponent<SeasonLoop>();
        }

        private void FixedUpdate()
        {
            LoopTimeSubject.LoopTimeReachedNotify(seasonLoop.nextLoopTime);
        }

    }
}