using Assets.Scripts.Plane;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameManager
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] GameObject plane;
        [SerializeField] SpriteRenderer planeSpriteRenderer;

        static PlaneManager planeManager;
        static Rigidbody2D planeRigidBody;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;

            if (SceneManager.GetActiveScene().name == "Game")
            {
                planeManager = plane.GetComponent<PlaneManager>();
                planeRigidBody = plane.GetComponent<Rigidbody2D>();
            }


        }

        public static void PauseGame()
        {
            planeRigidBody.simulated = false;
            planeManager.enabled = false;
            Time.timeScale = 0f;
        }

        public static void ResumeGame()
        {
            planeRigidBody.simulated = true;
            planeManager.enabled = true;
            Time.timeScale = 1f;
        }

        public string sceneName; // Yüklemek istediğiniz sahnenin adı,
        public AsyncOperation asyncLoad;





        public static void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public static void QuitGame()
        {
            Application.Quit();
        }


    }
}