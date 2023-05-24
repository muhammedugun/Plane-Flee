﻿using Assets.Scripts.GameManager;
using Assets.Scripts.Plane.ObserverPattern;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class MenuManager : MonoBehaviour
    {
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
                GameController.ResumeGame(gameMenu.mobileInputController);
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
            PlayerPrefs.SetInt("currentScore", scoreDisplay.score);
            UnscaledTimeInvoke.Invoke(ShowGameOverPanel, 0.5f);
        }

        void ShowGameOverPanel()
        {
            SceneManager.LoadScene("GameOver");
        }

  
    }
}