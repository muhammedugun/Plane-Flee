using Assets.Scripts.Ads;
using Assets.Scripts.GameManager;
using Assets.Scripts.Sound;
using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public static event Action OnMusicButton, OnSoundEffectButton;
        [SerializeField] SoundController musicsController, soundEffectsController;
        [SerializeField] GameObject mainPanel, skinsPanel;
        [SerializeField] GameObject musicButton, soundEffectButton;
        [SerializeField] Sprite musicOnSprite, musicOffSprite, soundEffectOnSprite, soundEffectOffSprite;

        public GameController gameController;

        private void Start()
        {
            MusicButtonControlStart();
            if(soundEffectsController!=null)
                SoundEffectButtonControlStart();
        }

        public void MusicButtonControlStart()
        {
            var musicImage = musicButton.GetComponent<Image>();
            if (musicsController.CheckActive())
            {
                musicImage.sprite = musicOnSprite;
            }
            else
            {
                musicImage.sprite = musicOffSprite;
            }
        }

        public void SoundEffectButtonControlStart()
        {
            var soundEffectImage = soundEffectButton.GetComponent<Image>();

            if (soundEffectsController.CheckActive())
            {
                soundEffectImage.sprite = soundEffectOnSprite;
            }
            else
            {
                soundEffectImage.sprite = soundEffectOffSprite;
            }
        }

        public void QuitButton()
        {
            GameController.QuitGame();

        }
        public static bool isEventRegistered = false;

        public void PlayButton()
        {
            if (PlayerPrefs.HasKey("GameOverCount"))
            {
                //Debug.Log("HasKey");
                if (PlayerPrefs.GetInt("GameOverCount") >= 5 && Time.time >= AdManager.nextTime)
                {
                    //Debug.Log("GetInt");
                    PlayerPrefs.SetInt("GameOverCount", 0);
                    AdManager.nextTime = Time.time + 420f;
                    if (!AdManager.isAdRequest)
                    {
                        //Debug.Log("isAdRequest false");
                        AdManager.Instance.LoadInterstitialAd();
                        LoadPlayGame();
                    }
                    else
                    {
                        //Debug.Log("ic else 2");
                        AdManager.Instance.interstitialAd.OnAdFullScreenContentClosed += LoadPlayGame;
                        AdManager.Instance.interstitialAd.OnAdFullScreenContentFailed += LoadPlayGame;
                        AdManager.Instance.ShowAd();
                    }

                }
                else
                {
                    //Debug.Log("ic else");
                    LoadPlayGame();
                }
            }  
            else
            {
                //Debug.Log("dis else");
                LoadPlayGame();
            }

        }

        public void LoadPlayGame(AdError adError)
        {
            gameController.PlayGame();
            AdManager.Instance.interstitialAd.OnAdFullScreenContentFailed -= LoadPlayGame;
        }

        public void LoadPlayGame()
        {
            gameController.PlayGame();
            AdManager.Instance.interstitialAd.OnAdFullScreenContentClosed -= LoadPlayGame;
        }

        public void SkinsButton()
        {
            skinsPanel.SetActive(true);
        }

        public void BackButton()
        {
            skinsPanel.SetActive(false);
            mainPanel.SetActive(true);
        }

        public void MusicButton()
        {
            OnMusicButton?.Invoke();
            var musicImage = musicButton.GetComponent<Image>();
           
            if (musicsController.CheckActive())
            {
                musicImage.sprite = musicOnSprite;
            }
            else
            {
                musicImage.sprite = musicOffSprite;
            }

        }

        public void SoundEffectButton()
        {
            OnSoundEffectButton?.Invoke();
            var soundEffectImage = soundEffectButton.GetComponent<Image>();

            if (soundEffectsController.CheckActive())
            {
                soundEffectImage.sprite = soundEffectOnSprite;
            }
            else
            {
                soundEffectImage.sprite = soundEffectOffSprite;
            }
        }

    }
}