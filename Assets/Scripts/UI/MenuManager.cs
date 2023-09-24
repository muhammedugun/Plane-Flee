using Assets.Scripts.GameManager;
using Assets.Scripts.Plane.ObserverPattern;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class MenuManager : MonoBehaviour
    {
        
        public GameController gameController;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] ScoreDisplay scoreDisplay;
        [SerializeField] GameMenu gameMenu;



        private void Start()
        {
            GameController.PauseGame();
            TriggerSubject.OnTriggerEnter += ShowGameOverPanelInvoke;
        }

        private void Update()
        {
            if (Time.timeScale == 0f && Input.touchCount > 0 && !gameMenu.isPausePanelActive)
            {
                GameController.ResumeGame();
                gameMenu.startPanel.SetActive(false);
            }
            
        }

        private void OnDisable()
        {
            TriggerSubject.OnTriggerEnter -= ShowGameOverPanelInvoke;
        }

        
        public void ShowGameOverPanelInvoke()
        {
            // değer daha önce oluşturulmamışsa
            if (!PlayerPrefs.HasKey("bestScore"))
            {
                PlayerPrefs.SetInt("bestScore", 0);
                PlayerPrefs.Save();
            }
            if(scoreDisplay.currentScore > PlayerPrefs.GetInt("bestScore"))
            {
                PlayerPrefs.SetInt("bestScore", scoreDisplay.currentScore);
                PlayerPrefs.Save();
            }
            UnscaledTimeInvoke.Invoke(ShowGameOverPanel, 2f);
        }

        void ShowGameOverPanel()
        {
            gameOverPanel.SetActive(true);

        }

  
    }
}