using UnityEngine;

namespace Assets.Scripts.GameManager
{
    public class UnscaledTimeInvoke : MonoBehaviour
    {
        public delegate void DelayedFunction();
        static DelayedFunction delayedFunction;
        private static float delayTime = 1f; // Gecikme süresi

        private static float elapsedTime = 0f;
        private static bool isDelaying = false;

        private void Update()
        {
            // Gecikme kontrolü
            if (isDelaying)
            {
                elapsedTime += Time.unscaledDeltaTime; // timeScale bağımsız zaman geçişi
                if (elapsedTime >= delayTime)
                {
                    // Gecikme süresi tamamlandı, fonksiyonu çağır
                    delayedFunction();
                    StopDelay();
                }
            }
        }


        public static void Invoke(DelayedFunction delayedFunct, float delaytime)
        {
            delayedFunction = delayedFunct;
            isDelaying = true;
            delayTime = delaytime;
            elapsedTime = 0f;
        }

        public void StopDelay()
        {
            isDelaying = false;
            elapsedTime = 0f;
        }

    }
}