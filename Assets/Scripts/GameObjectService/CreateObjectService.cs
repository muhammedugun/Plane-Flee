using UnityEngine;

namespace Assets.Scripts.GameObjectService
{
    public class CreateObjectService : MonoBehaviour
    {
        /// <summary>
        /// Parametre olarak gönderilen objeden 1 tane oluşturup, return eder
        /// </summary>
        /// <param name="gameObject">oluşturulacak obje</param>
        /// <returns></returns>
        public static GameObject CreateOne(GameObject gameObject)
        {
            return Instantiate(gameObject, Vector3.zero, Quaternion.identity);
        }

        /// <summary>
        /// Parametre olarak gönderilen objeden istenen adet kadar oluşturup, objeleri dizi olarak return eder
        /// </summary>
        /// <param name="gameObject">oluşturulacak obje</param>
        /// <param name="count">objeden kaç tane oluşturulacağı</param>
        /// <returns></returns>
        public static GameObject[] CreateMultiple(GameObject gameObject, int count)
        {
            GameObject[] gameObjects = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                gameObjects[i] = CreateOne(gameObject);
            }
            return gameObjects;

        }
    }
}