using UnityEngine;
using UnityEngine.SceneManagement;

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

            if (SceneManager.GetActiveScene().name == "Game" && Input.GetKeyDown(KeyCode.Escape) && !isOpenMenuActive)
            {
                OpenMenu();
            }
            if(Input.GetKeyDown(KeyCode.Escape))
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
