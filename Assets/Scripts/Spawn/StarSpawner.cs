using Assets.Scripts.GameObjectService;
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    public class StarSpawner : AbstractSpawner
    {
        public ObstacleSpawner obstacleSpawner;

        public override void MoveForward(Transform obstacle, GameObject spawnObject, float objectWidth=0)
        {
            spawnObjects[0].SetActive(true);
            var obstacleCollider = obstacle.GetComponent<PolygonCollider2D>();
            spawnObject.transform.position = SetRandomPosition(spawnObjects[0], obstacleCollider);
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
            float startPoint, xPos, yPos;
            var starSprite = star.GetComponent<SpriteRenderer>();
            if (obstacleCollider.bounds.center.y < 0)
            {
                startPoint = obstacleCollider.transform.position.y + obstacleCollider.bounds.size.y + starSprite.bounds.size.y;
                yPos = Random.Range(startPoint, startPoint + 2.1f);
            }
            else
            {
                startPoint = obstacleCollider.transform.position.y - obstacleCollider.bounds.size.y - starSprite.bounds.size.y;
                yPos = Random.Range(startPoint, startPoint - 2.1f);
            }
            xPos = Random.Range(startPoint - 2.2f, startPoint + 2.2f) + obstacleCollider.transform.position.x;
           
            return new Vector2(xPos, yPos);

        }

    }
}