using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Mobil platformlar için giriş kontrolleri yapmaktan sorumlu
    /// </summary>
    public class MobileInputController : MonoBehaviour
    {
        /// <summary>
        /// dokunma gerçekleşti mi?
        /// </summary>
        internal bool isTouch;
        private void Update()
        {
            if (!isTouch)
            {
                isTouch = CheckInput();
            }

        }
        /// <summary>
        /// Kullanıcı girdisini Touch metodu ile kontrol eder
        /// </summary>
        public bool CheckInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) return true;
                else return false;
            }
            else return isTouch;
        }

        
    }
}