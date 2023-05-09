using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    /// <summary>
    /// Kamera ile ilgili görevleri yönetmekten sorumlu
    /// </summary>
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] GameObject cameraObject;
        ICameraTracking cameraTracking;
        private void Awake()
        {
            cameraTracking = GetComponent<ICameraTracking>();
        }
        private void LateUpdate()
        {
            cameraTracking.FollowHorizontal(cameraObject);
        }
    }
}