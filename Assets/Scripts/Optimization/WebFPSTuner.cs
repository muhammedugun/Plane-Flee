using UnityEngine;

namespace Assets.Scripts.Optimization
{
    public class WebFPSTuner :  AbstractFPSTuner
    {
        /// <summary>
        /// Web platform'u için en yüksek FPS değerini ayarlar.
        /// Varsayılan olarak WebGL, tarayıcının render döngüsü zamanlamasıyla eşleşen bir kare hızı seçmesine izin verir. 
        /// Bu metot, tarayıcının seçilen kare hızını kullanmak için Application.targetFrameRate öğesini -1 olarak ayarlar.
        /// </summary>
        public override void SetToMaximumFPS()
        {
            Application.targetFrameRate = -1;
        }

       
    }
}