using Assets.Scripts.GameObjectService;
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    public class StarSpawner : AbstractSpawner
    {
        public ObstacleSpawner obstacleSpawner;

        public override void MoveForward(Transform obstacle, GameObject spawnObject, float objectWidth=0)
        {
            spawnObject.SetActive(true);
            var obstacleCollider = obstacle.GetComponent<PolygonCollider2D>();
            spawnObject.transform.position = SetRandomPosition(spawnObject, obstacleCollider);
            SpawnService.FixSpawnArrayIndexs(ref spawnObjects);

        }

        public override void MoveForwardMultiple(Transform lastObjectTransform=null, GameObject[] spawnObjects=null, float objectsWidth=0)
        {
            for (int i = 0; i < this.spawnObjects.Length; i++)
            {
                var obstacle = obstacleSpawner.spawnObjects[i];
                MoveForward(obstacle.transform, this.spawnObjects[0]);
     
            }
        }

        public override void SpawnContinuously()
        {
            var obstacle = obstacleSpawner.spawnObjects[obstacleSpawner.spawnObjects.Length - 1];
            MoveForward(obstacle.transform, spawnObjects[0]);
        }

        public override void SpawnFirst()
        {
            spawnObjects = CreateObjectService.CreateMultiple(spawnObjectPrefab, spawnObjectCount);
            MoveForwardMultiple();
        
        }

        Vector2 SetRandomPosition(GameObject star,PolygonCollider2D obstacleCollider)
        {
            float startPointY, xPos, yPos;
            var starCollider = star.GetComponent<Collider2D>();
            if (obstacleCollider.transform.position.y < 0)
            {
                startPointY = obstacleCollider.transform.position.y + obstacleCollider.bounds.size.y + starCollider.bounds.size.y;
                yPos = Random.Range(startPointY, startPointY + 1.7f);
            }
            else
            {
                startPointY = obstacleCollider.transform.position.y - obstacleCollider.bounds.size.y - starCollider.bounds.size.y;
                yPos = Random.Range(startPointY - 1.7f, startPointY);
            }
            xPos = obstacleCollider.transform.position.x + Random.Range(-2f, 2f);
           
            return new Vector2(xPos, yPos);

        }

    }
}