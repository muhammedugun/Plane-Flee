using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Uçak ile ilgili görevleri yönetir
    /// </summary>
    public class PlaneManager : MonoBehaviour
    {
        public AbstractPlaneMovement planeMovement;

       
        private void Awake()
        {
            planeMovement = GetComponent<AbstractPlaneMovement>();
      
        }
      
        private void FixedUpdate()
        {
            planeMovement.MoveHorizontal();
            planeMovement.MoveVertical();
        }


    }
}