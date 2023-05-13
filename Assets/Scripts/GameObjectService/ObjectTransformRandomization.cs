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
            gameObjectTransform.position = new Vector3(gameObjectTransform.position.x, randomY, gameObjectTransform.position.z);
        }


        public static void RandomizeHeightDouble(Transform gameObjectTransform1, Transform gameObjectTransform2)
        {
            gameObjectTransform1.localScale = new Vector3(0.5f, 0.7f, 1f);
            gameObjectTransform2.localScale = new Vector3(0.5f, 0.7f, 1f);



            float randomHeight = Random.Range(-2.5f, 0f);
            float object1Y = 10.5f + randomHeight;
            float object2Y = -6f + randomHeight;


            gameObjectTransform1.position = new Vector3(gameObjectTransform1.position.x, object1Y, gameObjectTransform1.position.z);
            gameObjectTransform2.position = new Vector3(gameObjectTransform2.position.x, object2Y, gameObjectTransform2.position.z);
        }

    }
}