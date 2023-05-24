using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class SoundEffectManager : MonoBehaviour
    {
        [SerializeField] SoundController soundEffectsController;
        
        void Start()
        {
            soundEffectsController.CheckCreateKey();
            soundEffectsController.VolumeControlStart();
        }

      
    }
}