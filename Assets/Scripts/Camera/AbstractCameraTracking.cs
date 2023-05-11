
using UnityEngine;

namespace Assets.Scripts.Camera
{
    /// <summary>
    /// Kamera takibi ile ilgili görevlerden sorumludur
    /// </summary>
    public abstract class AbstractCameraTracking : MonoBehaviour
    {
        /// <summary>
        /// Belirtilen objeyi yatay eksende takip eder
        /// </summary>
       public abstract void FollowHorizontal(GameObject cameraObject);
        
    }
}