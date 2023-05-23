using Assets.Scripts.GameManager;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] GameObject mainPanel;
        [SerializeField] GameObject skinsPanel;

        public void QuitButton()
        {
            GameController.QuitGame();

        }

        public void PlayButton()
        {
            GameController.PlayGame();
        }

        public void SkinsButton()
        {
            skinsPanel.SetActive(true);
        }

        public void BackButton()
        {
            skinsPanel.SetActive(false);
            mainPanel.SetActive(true);
        }
    }
}