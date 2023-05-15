using Assets.Scripts.GameObjectService;
using System;
using UnityEngine;


namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Engelleri spawnlama ile ilgili görevlerden sorumlu
    /// </summary>
    public class ObstacleSpawner : AbstractSpawner
    {
        [Tooltip("Objeler arasındaki minimum uzaklık")] public float minDistance;
        [Tooltip("Objeler arasındaki maksimum uzaklık")] public float maxDistance;
        [Tooltip("Yukarıda spawn olanların maks yüksekliği")] public float topMaxHeight = 7f;
        [Tooltip("Yukarıda spawn olanların min yüksekliği")] public float topMinHeight = 5.2f;
        [Tooltip("Aşağıda spawn olanların maks yüksekliği")] public float bottomMaxHeight = -5f;
        [Tooltip("Aşağıda spawn olanların min yüksekliği")] public float bottomMinHeight = -6.5f;

        /// <summary>
        /// Spawn gerçekleşti bildirimi
        /// </summary>        
        public static event Action OnSpawnDone;

        bool isUp;
        public override void MoveForward(Transform lastObjectTransform, GameObject spawnObject, float objectDistance)
        {
            var spawnPositionX = lastObjectTransform.position.x + objectDistance;
            spawnObject.transform.position = new Vector2(spawnPositionX, lastObjectTransform.position.y);
            ObjectTransformRandomization.RandomizeRotation(spawnObject.transform, -7f, 7f);

            SpawnService.FixSpawnArrayIndexs(ref spawnObjects);
        }

        public override void MoveForwardMultiple(Transform lastObjectTransform, GameObject[] spawnObjects, float objectDistance)
        {
            for (int i = 0; i < spawnObjects.Length; i++)
            {
                if (i == 0) 
                {
                    MoveForward(lastObjectTransform, spawnObjects[0], objectDistance);
                }
                else 
                {
                    MoveForward(spawnObjects[spawnObjects.Length-1].transform, spawnObjects[0], objectDistance);
                }
                SetHeight(spawnObjects[spawnObjects.Length - 1]);
            }
        }

        public override void SpawnContinuously()
        {
            float spawnDistanceRange = UnityEngine.Random.Range(minDistance, maxDistance);
            if(minDistance<2f)
            {
                SpawnDouble();
            }
            else
            {
                MoveForward(spawnObjects[spawnObjects.Length - 1].transform, spawnObjects[0], spawnDistanceRange);
                SetHeight(spawnObjects[spawnObjects.Length - 1]);
            }
            OnSpawnDone.Invoke();

        }


        public override void SpawnFirst()
        {
            spawnObjects = CreateObjectService.CreateMultiple(spawnObjectPrefab, spawnObjectCount);
            float spawnDistanceRange = UnityEngine.Random.Range(minDistance, maxDistance);
            MoveForwardMultiple(spawnStartPoint, spawnObjects, spawnDistanceRange);
        }

        /// <summary>
        /// Objeleri bir alt bir üst şeklinde ikili spawn eder
        /// </summary>
        void SpawnDouble()
        {
            float commonDistance = UnityEngine.Random.Range(maxDistance + 6f, maxDistance + 10f);

            MoveForward(spawnObjects[spawnObjects.Length - 1].transform, spawnObjects[0], commonDistance);
            MoveForward(spawnObjects[spawnObjects.Length - 1].transform, spawnObjects[0], 0);
            SetHeightDouble(spawnObjects[spawnObjects.Length - 2], spawnObjects[spawnObjects.Length - 1]);
        }

        /// <summary>
        /// Spawn objesini yukarı ya da aşağıya taşıyacak
        /// </summary>
        /// <param name="spawnObject"></param>
        void SetHeight(GameObject spawnObject)
        {
            float scaleY = Mathf.Abs(spawnObject.transform.localScale.y);
            if (isUp)
            {
                ObjectTransformRandomization.RandomizeHeight(spawnObject.transform, topMinHeight, topMaxHeight);
                spawnObject.transform.localScale = new Vector3(spawnObject.transform.localScale.x, -scaleY, spawnObject.transform.localScale.z);
                isUp = false;
            }
            else
            {
                ObjectTransformRandomization.RandomizeHeight(spawnObject.transform, bottomMinHeight, bottomMaxHeight);
                spawnObject.transform.localScale = new Vector3(spawnObject.transform.localScale.x, scaleY, spawnObject.transform.localScale.z);
                isUp = true;
            }
        }

        /// <summary>
        /// İkili şekilde gönderilen engellerin yüksekliğini ayarlar
        /// </summary>
        /// <param name="spawnObject1"></param>
        /// <param name="spawnObject2"></param>
        void SetHeightDouble(GameObject spawnObject1, GameObject spawnObject2)
        {
            ObjectTransformRandomization.RandomizeHeightDouble(spawnObject1.transform, spawnObject2.transform);

            spawnObject1.transform.localScale = new Vector3(spawnObject1.transform.localScale.x, -0.7f, 1f);
            spawnObject2.transform.localScale = new Vector3(spawnObject1.transform.localScale.x, 0.7f, 1f);
        }
    }
}