using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Uçağı hıza bağlı olarak hareket ettirme ile ilgili görevlerden sorumludur
    /// </summary>
    public class PlaneVelocityMovement : AbstractPlaneMovement
    {

        [SerializeField] Rigidbody2D planeRB;
        [SerializeField] AbstractVerticalMovement verticalMovement;
        private void Awake()
        {
            verticalMovement = GetComponent<AbstractVerticalMovement>();
        }

        public override void MoveHorizontal()
        {
            planeRB.velocity = new Vector2(horizontalSpeed, planeRB.velocity.y);
        }

        public override void MoveVertical()
        {
            verticalMovement.MoveVelocity(verticalSpeed, planeRB);
        }

    }
}