using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class SoundController : MonoBehaviour
    {
        public float volumeLevel;
        public string key;
        public AudioSource[] soundSources;

        /// <summary>
        /// Sesin aktiflik keyi yoksa oluşturur
        /// </summary>
        public void CheckCreateKey()
        {
            // değer daha önce oluşturulmamışsa
            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetInt(key, 1);
                PlayerPrefs.Save();
            }
        }

        /// <summary>
        /// Ses aktif mi değil mi?
        /// </summary>
        /// <returns></returns>
        public bool CheckActive()
        {
            if (PlayerPrefs.GetInt(key) == 1)
                return true;
            else
                return false;
        }
        public void SetActive(bool booling)
        {
            if (booling)
                PlayerPrefs.SetInt(key, 1);
            else
                PlayerPrefs.SetInt(key, 0);
            PlayerPrefs.Save();
        }

        public void VolumeControlStart()
        {
            if (CheckActive())
            {
                VolumeOn();
            }
            else
            {
                VolumeOff();
            }
        }


        public void VolumeControl()
        {
            if (CheckActive())
            {
                SetActive(false);
                VolumeOff();
            }
            else
            {
                SetActive(true);
                VolumeOn();
            }
        }

        public void VolumeOn()
        {
            foreach (var soundSource in soundSources)
            {
                soundSource.volume = volumeLevel;
            }
        }

        public void VolumeOff()
        {
            foreach (var soundSource in soundSources)
            {
                soundSource.volume = 0f;
            }
        }
    }
}