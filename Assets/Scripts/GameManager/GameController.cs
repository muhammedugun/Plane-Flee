using Assets.Scripts.Camera;
using Assets.Scripts.Plane;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameManager
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;
        [SerializeField] private GameObject _startZone;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _dynamicCanvas2;
        [SerializeField] private SpriteRenderer _planeSpriteRenderer;
        [SerializeField] private CameraManager _cameraManager;
        [SerializeField] private PlaneManager _planeManager;
        [SerializeField] private Rigidbody2D _planeRigidBody;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }

        private void Start()
        {
            PauseGame();
        }

        public void PauseGame()
        {
            _planeRigidBody.simulated = false;
            _planeManager.enabled = false;
            _cameraManager.enabled = false;
            _dynamicCanvas2.SetActive(false);
            Time.timeScale = 0f;
        }

        public void StartGame()
        {
            if (_startZone.activeSelf) { _startZone.SetActive(false); }
            if (_mainPanel.activeSelf) { _mainPanel.SetActive(false); }
            _cameraManager.enabled = true;
            _dynamicCanvas2.SetActive(true);
            Time.timeScale = 1f;
        }


        public void ResumeGame()
        {
            if (_mainPanel.activeSelf) { _mainPanel.SetActive(false); }
            _planeRigidBody.simulated = true;
            _planeManager.enabled = true;
            _cameraManager.enabled = true;
            _dynamicCanvas2.SetActive(true);
            Time.timeScale = 1f;
        }


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