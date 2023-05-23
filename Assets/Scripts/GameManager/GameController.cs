using Assets.Scripts.Plane;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameManager
{
    public class GameController : MonoBehaviour
    {
        
        [SerializeField] GameObject plane;
        static PlaneManager planeManager;
        static Rigidbody2D planeRigidBody;

        private void Awake()
        {
            planeManager = plane.GetComponent<PlaneManager>();
            planeRigidBody = plane.GetComponent<Rigidbody2D>();
        }

        public static void PauseGame(MobileInputController mobileInputController = null)
        {
            if(mobileInputController!=null)
            mobileInputController.enabled = false;
            planeRigidBody.simulated = false;
            planeManager.enabled = false;
            Time.timeScale = 0f;
        }

        public static void ResumeGame(MobileInputController mobileInputController)
        {
            mobileInputController.enabled = true;
            planeRigidBody.simulated = true;
            planeManager.enabled = true;
            Time.timeScale = 1f;
        }

        public static void PlayGame()
        {
            SceneManager.LoadScene("Game");
        }

        public static void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static void QuitGame()
        {
            Application.Quit();
        }
    }
}