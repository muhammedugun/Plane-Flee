using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraPlaneTracking : AbstractCameraTracking
    {

        [SerializeField] Transform planeTransform;
        [SerializeField] float horizontalDistance;
        /// <summary>
        /// Uçağı x ekseninde takip eder
        /// </summary>
        /// <param name="cameraObject"></param>
        public override void FollowHorizontal(GameObject cameraObject)
        {
            
            cameraObject.transform.position= new Vector3(planeTransform.position.x + horizontalDistance, cameraObject.transform.position.y, cameraObject.transform.position.z);
        }

    }
}