using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Optimization
{
    /// <summary>
    /// Mobil platform için fps'yi yönetmekle ilgili görevleri üstlenir
    /// </summary>
    public class MobileFPSTuner : MonoBehaviour, IFPSTuner
    {
        /// <summary>
        /// Mobil platform'da maximum FPS için FPS'yi ekran yenileme oranına ayarlar
        /// </summary>
        public void SetToMaximumFPS()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
        }

        
    }
}