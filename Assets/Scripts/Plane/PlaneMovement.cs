using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Uçağı hareket ettirme ile ilgili görevlerden sorumludur
    /// </summary>
    public class PlaneMovement : MonoBehaviour
    {
        /// <summary>
        /// Yatay hareket hızı
        /// </summary>
        public float horizontalSpeed = 1f;
        /// <summary>
        /// Dikey hareket hızı
        /// </summary>
        public float verticalSpeed = 1f;

        /// <summary>
        /// rotasyon hızı
        /// </summary>
        public float rotationSpeed;

        [SerializeField] Rigidbody2D planeRB;


        /// <summary>
        /// Uçağı yatay eksende hareket ettirir
        /// </summary>
        public void MoveHorizontal()
        {
            planeRB.velocity = new Vector2(horizontalSpeed, planeRB.velocity.y);
        }

        /// <summary>
        /// Uçağı dikey eksende hareket ettirir
        /// </summary>
        public void MoveVertical(ref bool isInput)
        {
            if (isInput)
            {
                planeRB.velocity = new Vector2(planeRB.velocity.x, verticalSpeed);
                isInput = false;
            }
        }


        public void SetRotation()
        {
            planeRB.transform.rotation = Quaternion.Euler(0f, 0f, planeRB.velocity.y * rotationSpeed);
        }

    }
}