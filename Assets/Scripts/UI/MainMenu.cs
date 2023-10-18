using Assets.Scripts.GameManager;
using Assets.Scripts.Sound;

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public static event Action OnSoundEffectButton;
        [SerializeField] SoundController musicsController, soundEffectsController;
        [SerializeField] GameObject mainPanel, skinsPanel, weaponsPanel;
        [SerializeField] GameObject musicButton, soundEffectButton;
        [SerializeField] Sprite musicOnSprite, musicOffSprite, soundEffectOnSprite, soundEffectOffSprite;

        public GameController gameController;

        private void Start()
        {
            MusicControlToStart();
            if (soundEffectsController!=null)
                SoundEffectButtonControlStart();
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


        public void ActiveSkinsButton()
        {
            skinsPanel.SetActive(true);
        }

        public void ActiveWeaponsButton()
        {
            weaponsPanel.SetActive(true);
        }

        public void DeactiveSkinsButton()
        {
            skinsPanel.SetActive(false);
        }

        public void DeactiveWeaponsButton()
        {
            weaponsPanel.SetActive(false);
        }

        public void BackButton()
        {
            skinsPanel.SetActive(false);
            mainPanel.SetActive(true);
        }

        public void MusicControlToStart()
        {
            var musicImage = musicButton.GetComponent<Image>();

            if (musicsController.CheckActive())
            {
                musicImage.sprite = musicOnSprite;
                musicsController.VolumeOn();
            }
            else
            {
                musicImage.sprite = musicOffSprite;
                musicsController.VolumeOff();
            }

        }

        public void MusicButton()
        {
            var musicImage = musicButton.GetComponent<Image>();
           
            if (musicsController.CheckActive())
            {
                musicImage.sprite = musicOffSprite;
                musicsController.SetActive(false);
                musicsController.VolumeOff();
            }
            else
            {
                musicImage.sprite = musicOnSprite;
                musicsController.SetActive(true);
                musicsController.VolumeOn();
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