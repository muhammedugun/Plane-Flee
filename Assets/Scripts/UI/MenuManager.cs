using Assets.Scripts.GameManager;
using Assets.Scripts.Plane.ObserverPattern;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class MenuManager : MonoBehaviour
    {
        
        [SerializeField] private GameController _gameController;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] ScoreDisplay scoreDisplay;
        [SerializeField] GameMenu gameMenu;



        private void Start()
        {
            TriggerSubject.OnTriggerEnter += ShowGameOverPanelInvoke;
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