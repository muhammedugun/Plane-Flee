using Assets.Scripts.GameObjectService;
using System;
using UnityEngine;


namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Engelleri aralıklı olarak spawnlama ile ilgili görevlerden sorumlu
    /// </summary>
    public class ObstacleSpawner : AbstractSpawner
    {
        [Tooltip("Objeler arasındaki minimum uzaklık")] public float minDistance;
        [Tooltip("Objeler arasındaki maksimum uzaklık")] public float maxDistance;
        [Tooltip("Yukarıda spawn olanların maks yüksekliği")] public float topMaxHeight = 7f;
        [Tooltip("Yukarıda spawn olanların min yüksekliği")] public float topMinHeight = 5.2f;
        [Tooltip("Aşağıda spawn olanların maks yüksekliği")] public float bottomMaxHeight = -5f;
        [Tooltip("Aşağıda spawn olanların min yüksekliği")] public float bottomMinHeight = -6.5f;


        bool isUp;
        /// <summary>
        /// Spawn gerçekleşti bildirimi
        /// </summary>
        /// 
        
        public static event Action OnSpawnDone;

        public override void MoveForward(Transform lastObjectTransform, GameObject spawnObject, float objectDistance)
        {
            var spawnPositionX = lastObjectTransform.position.x + objectDistance;
            spawnObject.transform.position = new Vector2(spawnPositionX, lastObjectTransform.position.y);

            ObjectTransformRandomization.RandomizeRotation(spawnObject.transform, -7f, 7f);
        }

        public override void MoveForwardMultiple(Transform lastObjectTransform, GameObject[] spawnObjects, float objectsWidth)
        {
            for (int i = 0; i < spawnObjects.Length; i++)
            {
                if (i == 0) 
                {
                    MoveForward(lastObjectTransform, spawnObjects[i], objectsWidth);
                    SetHeight(spawnObjects[i]);
                }
                else 
                {
                    MoveForward(spawnObjects[i - 1].transform, spawnObjects[i], objectsWidth);
                    SetHeight(spawnObjects[i]);
                }

            }
        }

        public override void SpawnContinuously()
        {
            float groundWidth = ObjectPhysicalInfoService.FindWidth(spawnObjects[0].GetComponent<Collider2D>());
            float spawnDistanceRange = UnityEngine.Random.Range(minDistance, maxDistance);
            if(minDistance<2f)
            {
                SpawnDouble();
            }
            else
            {
                MoveForward(spawnObjects[spawnObjects.Length - 1].transform, spawnObjects[0], spawnDistanceRange);
                SetHeight(spawnObjects[0]);
            }
            SpawnService.FixSpawnArrayIndexs(ref spawnObjects);
            OnSpawnDone.Invoke();

        }

        void SpawnDouble()
        {
            float newDistance = UnityEngine.Random.Range(maxDistance + 6f, maxDistance + 10f);

            MoveForward(spawnObjects[spawnObjects.Length - 1].transform, spawnObjects[0], newDistance);
            SpawnService.FixSpawnArrayIndexs(ref spawnObjects);
            MoveForward(spawnObjects[spawnObjects.Length - 1].transform, spawnObjects[0], 0);
            SetHeightDouble(spawnObjects[spawnObjects.Length - 1], spawnObjects[0]);
        }

        public override void SpawnFirst()
        {
            spawnObjects = CreateObjectService.CreateMultiple(spawnObjectPrefab, spawnObjectCount);
            float groundWidth = ObjectPhysicalInfoService.FindWidth(spawnObjects[0].GetComponent<Collider2D>());
            float spawnDistanceRange = UnityEngine.Random.Range(minDistance, maxDistance);
            MoveForwardMultiple(spawnStartPoint, spawnObjects, spawnDistanceRange);
        }

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

        void SetHeightDouble(GameObject spawnObject1, GameObject spawnObject2)
        {
            
            ObjectTransformRandomization.RandomizeHeightDouble(spawnObject1.transform, spawnObject2.transform);
            float scaleY = Mathf.Abs(spawnObject1.transform.localScale.y);

            spawnObject1.transform.localScale = new Vector3(spawnObject1.transform.localScale.x, -scaleY, spawnObject1.transform.localScale.z);
            spawnObject2.transform.localScale = new Vector3(spawnObject2.transform.localScale.x, scaleY, spawnObject2.transform.localScale.z);


        }
    }
}