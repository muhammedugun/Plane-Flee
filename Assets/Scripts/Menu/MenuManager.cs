using Assets.Scripts.GameManager;
using Assets.Scripts.Plane.ObserverPattern;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] ScoreDisplay scoreDisplay;
        [SerializeField] GameObject pausePanel;
        [SerializeField] GameObject startPanel;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] TextMeshProUGUI highestScoreTMP;
        [SerializeField] TextMeshProUGUI currentScoreTMP;
        bool isPausePanelActive = false;



        private void Start()
        {
            TriggerSubject.OnTriggerEnter += ShowGameOverPanelInvoke;
            Time.timeScale = 0f;
        }

        private void Update()
        {
            if (Time.timeScale == 0f && !isPausePanelActive && Input.touchCount > 0)
            {
                GameController.ResumeGame();
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
            GameController.PauseGame();
            pausePanel.SetActive(true);

        }

        public void ResumeButton()
        {
            pausePanel.SetActive(false);
            startPanel.SetActive(true);
            UnscaledTimeInvoke.Invoke(IsPausePanelActiveFalse, 0.1f);
        }

        public void RestartButton()
        {
            GameController.RestartGame();
        }

        public void MainMenuButton()
        {
            SceneManager.LoadScene(0);
        }

        public void QuitButton()
        {
            GameController.QuitGame();
            
        }

        public void IsPausePanelActiveFalse()
        {
            isPausePanelActive = false;
        }

        public void ShowGameOverPanelInvoke()
        {
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
                // yeni skor kazanıldı ile ilgili observer işlemleri
            }
            highestScoreTMP.text = "Highest Score: " + PlayerPrefs.GetInt("highestScore").ToString();
            currentScoreTMP.text = "Current Score: " + scoreDisplay.score.ToString();
            UnscaledTimeInvoke.Invoke(ShowGameOverPanel, 1f);
        }

        void ShowGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }


    }
}