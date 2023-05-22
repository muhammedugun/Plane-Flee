using Assets.Scripts.Collection;
using Assets.Scripts.ObserverPattern;


namespace Assets.Scripts.GameManager
{
    public class GameManagerObserverManager : AbstractObserverManager
    {
        [UnityEngine.SerializeField] ScoreDisplay scoreDisplay;
        
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
            
            StarCollection.OnCollectStar += scoreDisplay.UpdateScore;
        }

        public override void UnsubscribeToEvents()
        {
            StarCollection.OnCollectStar -= scoreDisplay.UpdateScore;
        }

        
    }
}