using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Optimization
{
    /// <summary>
    /// FPS'i ayarlamakla ilgili görevleri üstlenir
    /// </summary>
    public interface IFPSTuner
    {
        /// <summary>
        /// FPS'yi mevcut platform (Web, Mobil vb.) için en ideal ve en yüksek fps için ayarlar
        /// </summary>
        void SetToMaximumFPS();

        
    }
}