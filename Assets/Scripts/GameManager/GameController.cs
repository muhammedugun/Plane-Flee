using Assets.Scripts.Camera;
using Assets.Scripts.Plane;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameManager
{
    public class GameController : MonoBehaviour
    {
        internal static event Action OnStartGame;
        [SerializeField] private GameObject _camera;
        [SerializeField] private GameObject _startZone;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _dynamicCanvas2;
        [SerializeField] private GameObject _pauseButton, _changeWeaponButton, _musicButton, _soundEffectButton;
        [SerializeField] private SpriteRenderer _planeSpriteRenderer;
        [SerializeField] private CameraManager _cameraManager;
        [SerializeField] private PlaneManager _planeManager;
        [SerializeField] private Rigidbody2D _planeRigidBody;
        private int startCount = 0;

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
            if (startCount == 0)
            {
                if (_startZone.activeSelf) { _startZone.SetActive(false); }
                if (_mainPanel.activeSelf) { _mainPanel.SetActive(false); }
                _cameraManager.enabled = true;
                _dynamicCanvas2.SetActive(true);
                Time.timeScale = 1f;
                startCount++;
            }
            else
            {
                if (_startZone.activeSelf) { _startZone.SetActive(false); }
                ResumeGame();
            }
            _pauseButton.SetActive(true);
            _changeWeaponButton.SetActive(true);
            _musicButton.SetActive(true);
            _soundEffectButton.SetActive(true);
            OnStartGame.Invoke();

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