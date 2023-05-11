using Assets.Scripts.GameObjectService;
using System;
using UnityEngine;


namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Ardışık şekilde zemin oluşturma ile ilgili görevlerden sorumlu
    /// </summary>
    public class ConsecutiveGroundSpawner : AbstractSpawner
    {
        /// <summary>
        /// Spawn gerçekleşti bildirimi
        /// </summary>
        public static event Action OnSpawnDone;

        public override void SpawnFirst()
        {
            spawnObjects = CreateObjectService.CreateMultiple(spawnObjectPrefab, 4);
            float groundWidth = ObjectPhysicalInfoService.FindWidth(spawnObjects[0].GetComponent<Collider2D>());
            MoveForwardMultiple(spawnStartPoint, spawnObjects, groundWidth);
        }

        public override void SpawnContinuously()
        {
            float groundWidth = ObjectPhysicalInfoService.FindWidth(spawnObjects[0].GetComponent<Collider2D>());
            MoveForward(spawnObjects[spawnObjects.Length-1].transform, spawnObjects[0], groundWidth);
            SpawnService.FixSpawnArrayIndexs(ref spawnObjects);
            OnSpawnDone.Invoke();

        }


        public override void MoveForward(Transform lastGround, GameObject ground, float groundWidth)
        {
            var spawnPositionX = lastGround.position.x + groundWidth;
            ground.transform.position = new Vector2(spawnPositionX, -5f);
        }

        public override void MoveForwardMultiple(Transform lastGround, GameObject[] grounds, float groundWidth)
        {
            for (int i = 0; i < grounds.Length; i++)
            {
                if(i==0) MoveForward(lastGround, grounds[i], groundWidth);
                else MoveForward(grounds[i-1].transform, grounds[i], groundWidth);

            }
        }

    }
}