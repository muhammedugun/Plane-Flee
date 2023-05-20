using UnityEngine;

namespace Assets.Scripts.Camera
{
    /// <summary>
    /// Kamera ile ilgili görevleri yönetmekten sorumlu
    /// </summary>
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] GameObject cameraObject;
        AbstractCameraTracking cameraTracking;
        private void Awake()
        {
            cameraTracking = GetComponent<AbstractCameraTracking>();
        }
        private void LateUpdate()
        {
            cameraTracking.FollowHorizontal(cameraObject);
        }
    }
}