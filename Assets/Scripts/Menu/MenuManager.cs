using Assets.Scripts.Audio;
using Assets.Scripts.GameManager;
using Assets.Scripts.Plane;
using Assets.Scripts.Plane.ObserverPattern;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] ScoreDisplay scoreDisplay;
        [SerializeField] internal GameObject pausePanel;
        [SerializeField] internal GameObject startPanel;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] TextMeshProUGUI highestScoreTMP;
        [SerializeField] TextMeshProUGUI currentScoreTMP;
        [SerializeField] MobileInputController mobileInputController;
        internal bool isPausePanelActive = false;
        internal bool isGameOverPanelActive = false;

        [SerializeField] AudioManager audioManager;
        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioSource[] allAudioSources;
        [SerializeField] Sprite musicOnSprite, musicOffSprite, audioOnSprite, audioOffSprite;
        [SerializeField] GameObject musicButton, audioButton;
        private void Start()
        {
            GameController.PauseGame();
            TriggerSubject.OnTriggerEnter += ShowGameOverPanelInvoke;

            
            // değer daha önce oluşturulmamışsa
            if (!PlayerPrefs.HasKey("isMusicActive"))
            {
                PlayerPrefs.SetInt("isMusicActive", 1);
                PlayerPrefs.Save();
            }
            var musicImage = musicButton.GetComponent<Image>();
            // ses kapalı değilse
            if (PlayerPrefs.GetInt("isMusicActive") == 1)
            {
                musicSource.volume = 0.5f;
                musicImage.sprite = musicOnSprite;

            }
            else
            {
                musicSource.volume = 0f;
                musicImage.sprite = musicOffSprite;
            }


            // değer daha önce oluşturulmamışsa
            if (!PlayerPrefs.HasKey("isAudioActive"))
            {
                PlayerPrefs.SetInt("isAudioActive", 1);
                PlayerPrefs.Save();
            }
            var audioImage = audioButton.GetComponent<Image>();
            // ses kapalı değilse
            if (PlayerPrefs.GetInt("isAudioActive") == 1)
            {
                foreach (var audioSource in allAudioSources)
                {
                    audioSource.volume = 0.5f;
                }
                audioImage.sprite = audioOnSprite;

            }
            else
            {
                foreach (var audioSource in allAudioSources)
                {
                    audioSource.volume = 0f;
                }
                audioImage.sprite = audioOffSprite;
            }

        }

        private void Update()
        {
            if (Time.timeScale == 0f && Input.touchCount > 0 && !isPausePanelActive && !isGameOverPanelActive )
            {
                GameController.ResumeGame(mobileInputController);
                startPanel.SetActive(false);
            }
            
        }

        private void OnDisable()
        {
            TriggerSubject.OnTriggerEnter -= ShowGameOverPanelInvoke;
        }

        public void PauseButton()
        {
            isPausePanelActive = true;
            GameController.PauseGame(mobileInputController);
            pausePanel.SetActive(true);

        }

        public void ResumeButton()
        {
            pausePanel.SetActive(false);
            startPanel.SetActive(true);

            //StartCoroutine(IsPausePanelActiveFalse());
            UnscaledTimeInvoke.Invoke(IsPausePanelActiveFalse, 0.1f);
        }

        
        public void RestartButton()
        {
            GameController.RestartGame();
        }

        public void MainMenuButton()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void QuitButton()
        {
            GameController.QuitGame();
            
        }

        public void IsPausePanelActiveFalse()
        {
            //yield return new WaitForSeconds(0.1f);
            isPausePanelActive = false;
        }

        public void ShowGameOverPanelInvoke()
        {
            isGameOverPanelActive = true;
            // değer daha önce oluşturulmamışsa
            if (!PlayerPrefs.HasKey("highestScore"))
            {
                PlayerPrefs.SetInt("highestScore", 0);
                PlayerPrefs.Save();
            }
            if(scoreDisplay.score > PlayerPrefs.GetInt("highestScore"))
            {
                PlayerPrefs.SetInt("highestScore", scoreDisplay.score);
                PlayerPrefs.Save();
            }
            highestScoreTMP.text = "Highest Score: " + PlayerPrefs.GetInt("highestScore").ToString();
            currentScoreTMP.text = "Current Score: " + scoreDisplay.score.ToString();
            UnscaledTimeInvoke.Invoke(ShowGameOverPanel, 0.5f);
            //UnscaledTimeInvoke.Invoke(AudioManager.NewRecord, 0.5f);
            StartCoroutine(AudioManager.NewRecord());
        }

        void ShowGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        public void MusicButton()
        {
            var musicImage = musicButton.GetComponent<Image>();
            // ses kapalı değilse
            if (PlayerPrefs.GetInt("isMusicActive")==1)
            {
                musicSource.volume = 0;
                PlayerPrefs.SetInt("isMusicActive", 0);
                PlayerPrefs.Save();
                musicImage.sprite = musicOffSprite;
                
            }
            else
            {
                musicSource.volume = 0.5f;
                PlayerPrefs.SetInt("isMusicActive", 1);
                PlayerPrefs.Save();
                musicImage.sprite = musicOnSprite;
            }
            
        }

        public void AudioButton()
        {
            var audioImage = audioButton.GetComponent<Image>();
            // ses kapalı değilse
            if (PlayerPrefs.GetInt("isAudioActive") == 1)
            {
                foreach (var audioSource in allAudioSources)
                {
                    audioSource.volume = 0;
                }
                
                PlayerPrefs.SetInt("isAudioActive", 0);
                PlayerPrefs.Save();
                audioImage.sprite = audioOffSprite;

            }
            else
            {
                foreach (var audioSource in allAudioSources)
                {
                    audioSource.volume = 0.5f;
                }
                PlayerPrefs.SetInt("isAudioActive", 1);
                PlayerPrefs.Save();
                audioImage.sprite = audioOnSprite;
            }
        }



    }
}