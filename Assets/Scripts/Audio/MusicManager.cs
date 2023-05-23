using Assets.Scripts.Menu;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] MenuManager menuManager;
        int currentGameMusicIndex=-1;
        public AudioClip[] musicClips;
        private static AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

      

        private void Update()
        {
            if (!audioSource.isPlaying && !menuManager.startPanel.activeInHierarchy && !menuManager.isGameOverPanelActive && !menuManager.pausePanel.activeInHierarchy)
            {
                currentGameMusicIndex++;
                if (currentGameMusicIndex > 2)
                {
                    currentGameMusicIndex = 0;
                }
                GameMusicLoop();
            }

            else if((menuManager.isGameOverPanelActive || menuManager.pausePanel.activeInHierarchy) && audioSource.isPlaying)
            {
                audioSource.Pause();
            }

            if(!menuManager.pausePanel.activeInHierarchy && !menuManager.isGameOverPanelActive && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        public void GameMusicLoop()
        {
            audioSource.clip = musicClips[currentGameMusicIndex];
            audioSource.Play();

        }
    }
}