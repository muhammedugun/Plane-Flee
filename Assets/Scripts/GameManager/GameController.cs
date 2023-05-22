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

        public static void PauseGame()
        {
            Time.timeScale = 0f;
            planeRigidBody.simulated = false;
            planeManager.enabled = false;
        }

        public static void ResumeGame()
        {
            Time.timeScale = 1f;
            planeRigidBody.simulated = true;
            planeManager.enabled = true;
        }

        public static void RestartGame()
        {

            //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static void QuitGame()
        {
            Application.Quit();
        }
    }
}