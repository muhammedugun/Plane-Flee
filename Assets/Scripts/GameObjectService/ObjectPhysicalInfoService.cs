using UnityEngine;

namespace Assets.Scripts.GameObjectService
{
    public class ObjectPhysicalInfoService : MonoBehaviour
    {
        /// <summary>
        /// Objenin genişliğini bulur.
        /// </summary>
        /// <param name="objectCollider">Örnek objenin collider bileşeni</param>
        public static float FindWidth(Collider2D objectCollider)
        {
            return objectCollider.bounds.size.x;

        }
    }
}