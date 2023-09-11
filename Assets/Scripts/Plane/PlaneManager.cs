using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Uçak ile ilgili görevleri yönetir
    /// </summary>
    public class PlaneManager : MonoBehaviour
    {
        public PlaneMovement planeMovement;


       
        private void Awake()
        {
            planeMovement = GetComponent<PlaneMovement>();

        }
      
        private void FixedUpdate()
        {
            planeMovement.MoveHorizontal();
            planeMovement.SetRotation();
        }


    }
}