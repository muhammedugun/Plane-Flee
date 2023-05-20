using Assets.Scripts.Collection;
using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Plane.ObserverPattern;


namespace Assets.Scripts.GameManager
{
    public class GameManagerObserverManager : AbstractObserverManager
    {
        [UnityEngine.SerializeField] ScoreDisplay scoreDisplay;
        GameOver gameOver;
        private void Awake()
        {
            gameOver = GetComponent<GameOver>();
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
            TriggerSubject.OnTriggerEnter += gameOver.PauseGame;
            StarCollection.OnCollectStar += scoreDisplay.UpdateScore;
        }

        public override void UnsubscribeToEvents()
        {
            TriggerSubject.OnTriggerEnter -= gameOver.PauseGame;
            StarCollection.OnCollectStar -= scoreDisplay.UpdateScore;
        }

        
    }
}