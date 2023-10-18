using Assets.Scripts.GameManager;
using Assets.Scripts.Plane.ObserverPattern;
using System;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class MenuManager : MonoBehaviour
    {
        internal static event Action OnGameOverPanel;
        [SerializeField] private GameController _gameController;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private ScoreDisplay _scoreDisplay;
        [SerializeField] private CoinDisplay _coinDisplay;
        [SerializeField] private GameMenu _gameMenu;



        private void Start()
        {
            TriggerSubject.OnTriggerEnter += ShowGameOverPanelInvoke;
        }

        private void OnDisable()
        {
            TriggerSubject.OnTriggerEnter -= ShowGameOverPanelInvoke;
        }

        
        /// <summary>
        /// Oyun bitti ekranını belirlenen süre sonunda gösterir
        /// </summary>
        public void ShowGameOverPanelInvoke()
        {
            // değer daha önce oluşturulmamışsa
            if (!PlayerPrefs.HasKey("bestScore"))
            {
                PlayerPrefs.SetInt("bestScore", 0);
                PlayerPrefs.Save();
            }
            if(_scoreDisplay.currentScore > PlayerPrefs.GetInt("bestScore"))
            {
                PlayerPrefs.SetInt("bestScore", _scoreDisplay.currentScore);
                PlayerPrefs.Save();
            }


            if (!PlayerPrefs.HasKey("coinCount"))
            {
                PlayerPrefs.SetInt("coinCount", 0);
                PlayerPrefs.Save();
            }

            if (!PlayerPrefs.HasKey("currentCoinCount"))
            {
                PlayerPrefs.SetInt("currentCoinCount", 0);
                PlayerPrefs.Save();
            }

            int totalCoinCount = PlayerPrefs.GetInt("coinCount") + _coinDisplay.coin;
            PlayerPrefs.SetInt("currentCoinCount", _coinDisplay.coin);
            PlayerPrefs.SetInt("coinCount", totalCoinCount);
            PlayerPrefs.SetInt("currentScore", _scoreDisplay.currentScore);
            PlayerPrefs.Save();
            

            UnscaledTimeInvoke.Invoke(ShowGameOverPanel, 2f);
        }

        /// <summary>
        /// Oyun bitti ekranını gösterir
        /// </summary>
        void ShowGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
            OnGameOverPanel.Invoke();
        }

  
    }
}