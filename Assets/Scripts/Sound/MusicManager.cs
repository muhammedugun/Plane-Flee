using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] SoundController musicsController;
        [SerializeField] Music gameMusic;

        private void Start()
        {
            musicsController.CheckCreateKey();
            musicsController.VolumeControlStart();
            if (gameMusic != null)
            {
                gameMusic.MultiPlay();
            }
           
        }

        private void LateUpdate()
        {
            if(gameMusic!=null)
            {
                gameMusic.MultiPlayUpdate();
            }
            
        }

    }
}
