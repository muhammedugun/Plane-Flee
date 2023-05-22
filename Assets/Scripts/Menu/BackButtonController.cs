using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Menu
{
    public class BackButtonController : MonoBehaviour
    {
        private float lastClickTime;
        private float doubleClickDelay = 0.2f;

        MenuManager menuManager;
        bool isOpenMenuActive;

        private void Awake()
        {
            menuManager = GetComponent<MenuManager>();
        }

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
            
            menuManager.PauseButton();
            isOpenMenuActive = true;
        }

        private void QuitApplication()
        {
            Application.Quit();
        }
    }

}
