using Assets.Scripts.Collection;
using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Plane;

namespace Assets.Scripts.Audio
{
    public class AudioObserverManager : AbstractObserverManager
    {

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
            StarCollection.OnCollectStar += AudioManager.Collect;
            PlaneMovement.OnFly += PlaneAudio.Fly;
        }

        public override void UnsubscribeToEvents()
        {
            StarCollection.OnCollectStar -= AudioManager.Collect;
            PlaneMovement.OnFly -= PlaneAudio.Fly;
        }

        
    }
}