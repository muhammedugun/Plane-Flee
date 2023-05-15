
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Spawnlama ile ilgili işlemlerden sorumludur
    /// </summary>
    public abstract class AbstractSpawner : MonoBehaviour
    {
        /// <summary>
        /// Kaç obje spawn edilecek bilgisi
        /// </summary>
        public int spawnObjectCount;

        /// <summary>
        /// Spawnlanacak objenin bir örneği
        /// </summary>
        public GameObject spawnObjectPrefab;

        /// <summary>
        /// Spawn'ın başlangıç noktası, pozisyonu
        /// </summary>
        public Transform spawnStartPoint;

        /// <summary>
        /// Spawnlanan objelerin tutulduğu dizi
        /// </summary>
        internal GameObject[] spawnObjects;

        /// <summary>
        /// Oyun başladığında ilk spawn yapılırken çalışacak fonksiyon
        /// </summary>
        public abstract void SpawnFirst();

        /// <summary>
        /// İlk spawndan sonra oyun döngüsü boyunca yapılacak spawn için çalışacak fonksiyon. Not: Observer olarak tetiklenip çalışması daha uygundur
        /// </summary>
        public abstract void SpawnContinuously();

        /// <summary>
        /// Parametre olarak gönderilen spawn nesnesini öne taşır
        /// </summary>
        /// <param name="lastObjectTransform">son üretilmiş ya da son konumda duran objenin transformu</param>
        /// <param name="spawnObject">Pozisyonu ayarlanacak obje</param>
        /// <param name="objectDistance">Pozisyonu ayarlanacak objenin önceki obje ile arasındaki mesafesi</param>
        public abstract void MoveForward(Transform lastObjectTransform, GameObject spawnObject, float objectDistance);


        /// <summary>
        /// Parametre olarak gönderilen spawn nesnelerini ardışık olarak öne taşır.
        /// </summary>
        /// <param name="lastObjectTransform">son üretilmiş ya da son konumda duran objenin pozisyonu</param>
        /// <param name="spawnObjects">Pozisyonu ayarlanacak objelerin transformu</param>
        /// <param name="objectsWidth">Pozisyonu ayarlanacak objelerin ortak genişliği</param>
        public abstract void MoveForwardMultiple(Transform lastObjectTransform, GameObject[] spawnObjects, float objectsWidth);

    }
}