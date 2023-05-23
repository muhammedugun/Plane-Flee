using Assets.Scripts.GameManager;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverPattern
{
    public class PlaneAnimationManager : MonoBehaviour
    {
        Animator animator;
        [SerializeField] RuntimeAnimatorController bangAnimatorController;
        MobileInputController mobileInputController;


        private void Awake()
        {
            mobileInputController = GetComponent<MobileInputController>();
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
            GameController.PauseGame(mobileInputController);
            animator.runtimeAnimatorController = bangAnimatorController;
        }

        
    }
}