using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class Music : MonoBehaviour
    {
        public AudioSource musicSource;
        public AudioClip musicClip;
        public AudioClip[] musicClips;

        internal int currentMusicIndex;

        public void Play()
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
        public void MultiPlay()
        {
            musicSource.clip = musicClips[currentMusicIndex];
            musicSource.Play();
        }

        public void MultiPlayUpdate()
        {
            if(!musicSource.isPlaying)
            {
                if(currentMusicIndex<musicClips.Length-1)
                    currentMusicIndex++;
                else
                    currentMusicIndex=0;
                MultiPlay();
            }
        }

    }
}