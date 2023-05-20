using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Uçak ile ilgili görevleri yönetir
    /// </summary>
    public class PlaneManager : MonoBehaviour
    {
        public PlaneMovement planeMovement;
        internal MobileInputController mobilInputController;

       
        private void Awake()
        {
            planeMovement = GetComponent<PlaneMovement>();
            mobilInputController = GetComponent<MobileInputController>();
        }
      
        private void FixedUpdate()
        {
            planeMovement.MoveHorizontal();
            planeMovement.MoveVertical(ref mobilInputController.isTouch);
            planeMovement.SetRotation();
        }


    }
}