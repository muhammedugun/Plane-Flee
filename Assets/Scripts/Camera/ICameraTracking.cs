
using UnityEngine;

namespace Assets.Scripts.Camera
{
    /// <summary>
    /// Kamera takibi ile ilgili görevlerden sorumludur
    /// </summary>
    public interface ICameraTracking
    {
        /// <summary>
        /// Belirtilen objeyi yatay eksende takip eder
        /// </summary>
        void FollowHorizontal(GameObject cameraObject);
        
    }
}