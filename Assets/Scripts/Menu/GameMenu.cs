using Assets.Scripts.Ads;
using Assets.Scripts.GameManager;
using Assets.Scripts.Plane;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class GameMenu : MonoBehaviour
    {

        
        [SerializeField] internal GameObject pausePanel;
        internal bool isPausePanelActive = false;
        public MobileInputController mobileInputController;
        [SerializeField] internal GameObject startPanel;
        [SerializeField] GameController gameController;
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

            UnscaledTimeInvoke.Invoke(IsPausePanelActiveFalse, 0.1f);
        
        }

        public void IsPausePanelActiveFalse()
        {
            isPausePanelActive = false;
        }


        public void RestartButton()
        {
            GameController.RestartGame();
        }
    
        public void MainMenuButton()
        {
            if(PlayerPrefs.HasKey("GameOverCount"))
            {
                if (PlayerPrefs.GetInt("GameOverCount") >= 5 && Time.time >= AdManager.nextTime)
                {
                    PlayerPrefs.SetInt("GameOverCount", 0);
                    AdManager.nextTime = Time.time + 420f;
                    if (!AdManager.isAdRequest)
                    {
                        AdManager.Instance.LoadInterstitialAd();
                        LoadMainMenu();
                    }
                    else
                    {
                        AdManager.Instance.interstitialAd.OnAdFullScreenContentClosed += LoadMainMenu;
                        AdManager.Instance.interstitialAd.OnAdFullScreenContentFailed += LoadMainMenu;
                        AdManager.Instance.ShowAd();
                    }
                }
                else
                {
                    LoadMainMenu();
                }

            }
            else
            {
                LoadMainMenu();
            }
        }

        public void LoadMainMenu(AdError adError)
        {
            SceneManager.LoadScene("MainMenu");
            AdManager.Instance.interstitialAd.OnAdFullScreenContentFailed -= LoadMainMenu;
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            AdManager.Instance.interstitialAd.OnAdFullScreenContentClosed -= LoadMainMenu;
        }


    }
}