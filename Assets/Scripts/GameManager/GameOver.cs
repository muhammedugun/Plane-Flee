using Assets.Scripts.Plane;
using UnityEngine;

namespace Assets.Scripts.GameManager
{
    public class GameOver : MonoBehaviour
    {
        
        [SerializeField] PlaneManager planeManager;
        [SerializeField] Animator planeAnimator;

        public void PauseGame()
        {
            //planeManager.mobilInputController.enabled = false;
            //planeManager.planeMovement.horizontalSpeed = 0;
            //planeAnimator.SetTrigger("bang");
            //Time.timeScale = 0;
        }
    }
}