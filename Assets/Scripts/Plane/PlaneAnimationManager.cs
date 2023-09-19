using Assets.Scripts.GameManager;
using UnityEngine;

namespace Assets.Scripts.Plane.ObserverPattern
{
    public class PlaneAnimationManager : MonoBehaviour
    {
        Animator animator;
        //[SerializeField] RuntimeAnimatorController bangAnimatorController;



        private void Awake()
        {

            animator = GetComponent<Animator>();
        }
        void Start()
        {
            TriggerSubject.OnTriggerEnter += SetAnimController;

            if (!PlayerPrefs.HasKey("checkMark"))
            {
                PlayerPrefs.SetInt("checkMark", 0);
            }
            else
            {
                switch (PlayerPrefs.GetInt("checkMark"))
                {
                    case 0:
                        animator.SetInteger("colorIndex", 0); break;
                    case 1:
                        animator.SetInteger("colorIndex", 1); break;
                    case 2:
                        animator.SetInteger("colorIndex", 2); break;
                    case 3:
                        animator.SetInteger("colorIndex", 3); break;
                    default:
                        break;
                }

            }
        }

        private void OnDisable()
        {
            TriggerSubject.OnTriggerEnter -= SetAnimController;
        }

        void SetAnimController()
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
            GameController.PauseGame();
            //animator.runtimeAnimatorController = bangAnimatorController;
            animator.SetTrigger("isDestroy");
        }

        
    }
}