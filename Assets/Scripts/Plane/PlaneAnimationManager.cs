using Assets.Scripts.GameManager;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverPattern
{
    public class PlaneAnimationManager : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;
        [SerializeField] private AnimatorController _planeAnimControlller;

        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        void Start()
        {
            TriggerSubject.OnTriggerEnter += SetAnimController;
        }

        private void OnDisable()
        {
            TriggerSubject.OnTriggerEnter -= SetAnimController;
        }

        void SetAnimController()
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
            _gameController.PauseGame();
            animator.SetTrigger("isDestroy");
        }

        public void DisableExplosionSprite()
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

        public void ChangeAnimController()
        {
            animator.runtimeAnimatorController = _planeAnimControlller;
            _gameController.ResumeGame();
        }

    }
}