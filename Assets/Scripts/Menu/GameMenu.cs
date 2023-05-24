using Assets.Scripts.GameManager;
using Assets.Scripts.Plane;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class GameMenu : MonoBehaviour
    {
     

        [SerializeField] internal GameObject pausePanel;
        internal bool isPausePanelActive = false;
        public MobileInputController mobileInputController;
        [SerializeField] internal GameObject startPanel;
        public void PauseButton()
        {
            isPausePanelActive = true;
            GameController.PauseGame(mobileInputController);
            pausePanel.SetActive(true);
           
        }

        public void ResumeButton()
        {
            pausePanel.SetActive(false);
            startPanel.SetActive(true);

            UnscaledTimeInvoke.Invoke(IsPausePanelActiveFalse, 0.1f);
        
        }

        public void IsPausePanelActiveFalse()
        {
            isPausePanelActive = false;
        }


        public void RestartButton()
        {
            GameController.RestartGame();
        }

        public void MainMenuButton()
        {
            SceneManager.LoadScene("MainMenu");
        }


    }
}