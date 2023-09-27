using System;
using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Uçağı hareket ettirme ile ilgili görevlerden sorumludur
    /// </summary>
    public class PlaneMovement : MonoBehaviour
    {
        /// <summary>
        /// Dikey olarak uçmaya başladıysam
        /// </summary>
        public static event Action OnFly;
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
        public void MoveVertical()
        {
            
            OnFly.Invoke();
            planeRB.velocity = new Vector2(planeRB.velocity.x, verticalSpeed);
        }


        public void SetRotation()
        {
            if(planeRB.velocity.y * rotationSpeed<25 && planeRB.velocity.y * rotationSpeed > -90)
            {
                planeRB.transform.rotation = Quaternion.Euler(0f, 0f, planeRB.velocity.y * rotationSpeed);
            }
            
        }

    }
}