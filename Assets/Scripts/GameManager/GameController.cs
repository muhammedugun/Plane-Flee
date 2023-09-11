using Assets.Scripts.Ads;
using Assets.Scripts.Plane;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameManager
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] GameObject plane;
        [SerializeField] SpriteRenderer planeSpriteRenderer;
        [SerializeField] Sprite yellowPlaneSprite, bluePlaneSprite, greenPlaneSprite, redPlaneSprite;
        static PlaneManager planeManager;
        static Rigidbody2D planeRigidBody;

        private void Awake()
        {
            if (SceneManager.GetActiveScene().name == "Game")
            {
                planeManager = plane.GetComponent<PlaneManager>();
                planeRigidBody = plane.GetComponent<Rigidbody2D>();
            }


        }
        private void Start()
        {
            if (SceneManager.GetActiveScene().name == "Game")
            {
                //Uçak skini ile ilgili işlemler
                if (!PlayerPrefs.HasKey("checkMark"))
                {
                    PlayerPrefs.SetInt("checkMark", 0);
                }
                else
                {
                    switch (PlayerPrefs.GetInt("checkMark"))
                    {
                        case 0:
                            planeSpriteRenderer.sprite = yellowPlaneSprite; break;
                        case 1:
                            planeSpriteRenderer.sprite = bluePlaneSprite; break;
                        case 2:
                            planeSpriteRenderer.sprite = greenPlaneSprite; break;
                        case 3:
                            planeSpriteRenderer.sprite = redPlaneSprite; break;
                        default:
                            break;
                    }

                }
                sceneName = "GameOver";
                LoadSceneAsync();
            }
            else if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                sceneName = "Game";
                LoadSceneAsync();
            }
            else if (SceneManager.GetActiveScene().name == "GameOver")
            {
                sceneName = "Game";
                LoadSceneAsync();
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


        public void PlayGame()
        {
            asyncLoad.allowSceneActivation = true;
           
        }

        public static void RestartGame()
        {
            SceneManager.LoadScene("Game");
        }

        public static void QuitGame()
        {
            Application.Quit();
        }

        private void LoadSceneAsync()
        {
            asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;
        }
    }
}