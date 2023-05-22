using Assets.Scripts.GameManager;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverPattern
{
    public class PlaneAnimationManager : MonoBehaviour
    {
        Animator animator;
        [SerializeField] RuntimeAnimatorController bangAnimatorController;

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
            GameController.PauseGame();
            animator.runtimeAnimatorController = bangAnimatorController;
        }
    }
}