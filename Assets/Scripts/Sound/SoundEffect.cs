using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class SoundEffect : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip audioClip;
        public void Play()
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}