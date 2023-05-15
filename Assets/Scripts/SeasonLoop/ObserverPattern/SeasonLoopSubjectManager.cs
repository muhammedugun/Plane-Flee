using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Spawn.ObserverPattern;


namespace Assets.Scripts.SeasonLoop.ObserverPattern
{
    public class SeasonLoopSubjectManager : AbstractSubjectManager
    {

        SeasonLoopManager seasonLoopManager;

        private void Awake()
        {
            seasonLoopManager = GetComponent<SeasonLoopManager>();
        }

        private void FixedUpdate()
        {
            LoopTimeSubject.LoopTimeReachedNotify(seasonLoopManager.nextLoopTime);
        }
    }
}