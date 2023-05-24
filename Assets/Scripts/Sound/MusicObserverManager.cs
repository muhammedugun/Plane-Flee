using Assets.Scripts.Menu;
using Assets.Scripts.ObserverPattern;


namespace Assets.Scripts.Sound
{
    public class MusicObserverManager : AbstractObserverManager
    {
        public SoundController musicsController;
        public Music gameMusic;
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
            MainMenu.OnMusicButton += musicsController.VolumeControl;
        }

        public override void UnsubscribeToEvents()
        {
            MainMenu.OnMusicButton -= musicsController.VolumeControl;
        }

    }
}