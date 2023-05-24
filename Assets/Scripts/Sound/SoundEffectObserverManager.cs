using Assets.Scripts.Collection;
using Assets.Scripts.Menu;
using Assets.Scripts.ObserverPattern;
using Assets.Scripts.Plane;


namespace Assets.Scripts.Sound
{
    public class SoundEffectObserverManager : AbstractObserverManager
    {
        public SoundEffect collectEffect;
        public SoundController soundEffectController;

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
            MainMenu.OnSoundEffectButton += soundEffectController.VolumeControl;
            StarCollection.OnCollectStar += collectEffect.Play;
            PlaneMovement.OnFly += PlaneSound.Fly;
        }

        public override void UnsubscribeToEvents()
        {
            MainMenu.OnSoundEffectButton -= soundEffectController.VolumeControl;
            StarCollection.OnCollectStar -= collectEffect.Play;
            PlaneMovement.OnFly -= PlaneSound.Fly;
        }

        
    }
}