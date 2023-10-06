using Assets.Scripts.Collection;
using Assets.Scripts.ObserverPattern;


namespace Assets.Scripts.GameManager
{
    public class GameManagerObserverManager : AbstractObserverManager
    {
        [UnityEngine.SerializeField] CoinDisplay coinDisplay;
        
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
            
            CoinCollection.OnCollectStar += coinDisplay.UpdateCoin;
        }

        public override void UnsubscribeToEvents()
        {
            CoinCollection.OnCollectStar -= coinDisplay.UpdateCoin;
        }

        
    }
}