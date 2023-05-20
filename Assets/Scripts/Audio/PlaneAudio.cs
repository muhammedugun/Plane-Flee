using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class PlaneAudio : MonoBehaviour
    {
        static AudioSource audioSource;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public static void Fly()
        {
            audioSource.Play();
        }
        
    }
}