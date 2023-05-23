using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class PlaneAudio : MonoBehaviour
    {
        [SerializeField] AudioClip explosion;
        static AudioSource audioSource;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public static void Fly()
        {
            audioSource.Play();
        }

        public void ExplosionSound()
        {
            audioSource.clip = explosion;
            audioSource.Play();
        }

    }
}