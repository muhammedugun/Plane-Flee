﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        
        public static AudioClip[] AudioClips;
        [SerializeField] AudioClip[] audioClips;
        private static AudioSource audioSource;
        private void Awake()
        {
            AudioClips = new AudioClip[audioClips.Length];
            audioSource = GetComponent<AudioSource>();
            AudioClips = audioClips;
            

        }

        public static void Collect()
        {
            audioSource.clip = AudioClips[0];
            audioSource.Play();
        }

        public static IEnumerator NewRecord()
        {
            yield return new WaitForSeconds(0.5f);
            audioSource.clip = AudioClips[1];
            audioSource.Play();
        }

    }
}