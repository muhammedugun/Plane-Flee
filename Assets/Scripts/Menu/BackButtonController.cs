using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class BackButtonController : MonoBehaviour
    {
        public GameMenu gameMenu;
        private float lastClickTime;
        private float doubleClickDelay = 0.2f;

        bool isOpenMenuActive;

       

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isOpenMenuActive)
            {
                OpenMenu();
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                OnPanelPointerClick();
            }
        }

        public void OnPanelPointerClick()
        {
            float currentTime = Time.realtimeSinceStartup;

            if (currentTime - lastClickTime <= doubleClickDelay)
            {
                QuitApplication();
            }

            lastClickTime = currentTime;
        }

        private void OpenMenu()
        {

            gameMenu.PauseButton();
            isOpenMenuActive = true;
        }

        private void QuitApplication()
        {
            Application.Quit();
        }
    }

}
