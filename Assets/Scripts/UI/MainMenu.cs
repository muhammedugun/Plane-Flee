using Assets.Scripts.GameManager;
using Assets.Scripts.Sound;

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
            LoadPlayGame();
        }


        public void LoadPlayGame()
        {
            gameController.PlayGame();

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