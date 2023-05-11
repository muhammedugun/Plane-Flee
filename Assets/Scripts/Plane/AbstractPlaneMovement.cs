using UnityEngine;

namespace Assets.Scripts.Plane
{
    /// <summary>
    /// Uçak hareketi ile ilgili görevlerden sorumlu.
    /// </summary>
    public abstract class AbstractPlaneMovement : MonoBehaviour
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
        /// Uçağı yatay eksende hareket ettirir
        /// </summary>
        public abstract void MoveHorizontal();

        /// <summary>
        /// Uçağı dikey eksende hareket ettirir
        /// </summary>
        public abstract void MoveVertical();

        
        
    }
}