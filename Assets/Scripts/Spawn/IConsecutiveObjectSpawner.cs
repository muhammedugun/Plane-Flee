
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Objeleri ardışık olarak spawn etmek ile ilgili görevlerden sorumlu
    /// </summary>
    public interface IConsecutiveObjectSpawner
    {
        /// <summary>
        /// spawnlanacak objenin bir örneği
        /// </summary>
        GameObject SpawnObjectPrefab { get; set; }
        /// <summary>
        /// Spawnlanan objelerin tutulduğu dizi
        /// </summary>
        GameObject[] SpawnObjects { get; set; }
        /// <summary>
        /// Spawn'ın başlangıç noktası, pozisyonu
        /// </summary>
        Transform SpawnStartPoint { get; set; }

        /// <summary>
        /// Oyun başladığında ilk spawn yapılırken çalışacak fonksiyon
        /// </summary>
        void SpawnFirst();

        /// <summary>
        /// İlk spawndan sonra oyun döngüsü boyunca yapılacak spawn için çalışacak fonksiyon. Not: Observer olarak tetiklenip çalışması daha uygundur
        /// </summary>
        void SpawnContinuously();
       
        /// <summary>
        /// Parametre olarak gönderilen spawn nesnesini öne taşır
        /// </summary>
        /// <param name="lastObjectTransform">son üretilmiş ya da son konumda duran objenin transformu</param>
        /// <param name="spawnObject">Pozisyonu ayarlanacak objenin transformu</param>
        /// <param name="objectWidth">Pozisyonu ayarlanacak objenin genişliği</param>
        void MoveForward(ref Transform lastObjectTransform, GameObject spawnObject, float objectWidth);

        /// <summary>
        /// Parametre olarak gönderilen spawn nesnelerini ardışık olarak öne taşır.
        /// </summary>
        /// <param name="lastObjectTransform">son üretilmiş ya da son konumda duran objenin pozisyonu</param>
        /// <param name="spawnObjects">Pozisyonu ayarlanacak objelerin transformu</param>
        /// <param name="objectsWidth">Pozisyonu ayarlanacak objelerin ortak genişliği</param>
        public void MoveForwardMultiple(ref Transform lastObjectTransform, GameObject[] spawnObjects, float objectsWidth);


        /// <summary>
        ///  geçici olarak buraya eklendi
        /// </summary>
        void SetFinalGround();
    }
}