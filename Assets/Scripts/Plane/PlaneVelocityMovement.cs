using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Uçağı hıza bağlı olarak hareket ettirme ile ilgili görevlerden sorumludur
    /// </summary>
    public class PlaneVelocityMovement : MonoBehaviour, IPlaneMovement
    {
        public float HorizontalSpeed { get { return horizontalSpeed; } set { horizontalSpeed = value; } }
        public float VerticalSpeed { get { return verticalSpeed; } set { verticalSpeed = value; } }

        [SerializeField] Rigidbody2D planeRB;
        [SerializeField] IVerticalMovement verticalMovement;
        [SerializeField] float horizontalSpeed = 1f;
        [SerializeField] float verticalSpeed = 1f;
        private void Awake()
        {
            verticalMovement = GetComponent<IVerticalMovement>();
        }

        public void MoveHorizontal()
        {
            planeRB.velocity = new Vector2(horizontalSpeed, planeRB.velocity.y);
        }

        public void MoveVertical()
        {
            verticalMovement.MoveVelocity(verticalSpeed, planeRB);
        }

    }
}