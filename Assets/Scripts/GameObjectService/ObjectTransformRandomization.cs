using UnityEngine;

namespace Assets.Scripts.GameObjectService
{
    public class ObjectTransformRandomization : MonoBehaviour
    {

        public static void RandomizeRotation(Transform gameObjectTransform, float minRotation, float maxRotation)
        {
            float randomZ = Random.Range(minRotation, maxRotation);
            gameObjectTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, randomZ));
        }

        /// <summary>
        /// Objenin y eksenindeki yüksekliğine, verilen aralıkta random bir değer verir
        /// </summary>
        /// <param name="gameObjectTransform"></param>
        /// <param name="minRotation"></param>
        /// <param name="maxRotation"></param>
        public static void RandomizeHeight(Transform gameObjectTransform, float minHeight, float maxHeight)
        {
            float randomY = Random.Range(minHeight, maxHeight);
            SetHeight(gameObjectTransform, randomY);
            //gameObjectTransform.position = new Vector3(gameObjectTransform.position.x, randomY, gameObjectTransform.position.z);
        }


        /// <summary>
        /// İkili gönderilen objelere biri aşağıda biri yukarda olacak şekilde, ortak ve rastgele bir yükseklik verir
        /// </summary>
        /// <param name="gameObjectTransform1"></param>
        /// <param name="gameObjectTransform2"></param>
        public static void RandomizeHeightDouble(Transform gameObjectTransform1, Transform gameObjectTransform2)
        {
            
            float commonRandomHeight = Random.Range(-2.5f, 0f);
            float object1Y = 10.5f + commonRandomHeight;
            float object2Y = -6f + commonRandomHeight;

            SetHeight(gameObjectTransform1, object1Y);
            SetHeight(gameObjectTransform2, object2Y);

            //gameObjectTransform1.position = new Vector3(gameObjectTransform1.position.x, object1Y, gameObjectTransform1.position.z);
            //gameObjectTransform2.position = new Vector3(gameObjectTransform2.position.x, object2Y, gameObjectTransform2.position.z);
        }


        /// <summary>
        /// objenin yüksekliğini parametrede verilen değere göre ayarlar
        /// </summary>
        /// <param name="gameObjectTransform"></param>
        /// <param name="height"></param>
        static void SetHeight(Transform gameObjectTransform, float height)
        {
            gameObjectTransform.position = new Vector3(gameObjectTransform.position.x, height, gameObjectTransform.position.z);
        }

    }
}