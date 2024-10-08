﻿using Assets.Scripts.GameObjectService;
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    public class CoinSpawner : AbstractSpawner
    {
        public ObstacleSpawner obstacleSpawner;

        public override void MoveForward(Transform obstacle, GameObject spawnObject, float objectWidth=0)
        {
            spawnObject.SetActive(true);
            spawnObject.transform.position = SetRandomPosition(obstacle);
            // Spawn dizisindeki objelerin indexlerini düzenler. Not: 1 spawn yapıldıktan sonra çağırılmalı
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

        // Gönderilen engelin konumuna göre random bir Vector2 pozisyonu döndürür
        Vector2 SetRandomPosition(Transform obstacle)
        {
            var obstacleCollider = obstacle.GetComponent<PolygonCollider2D>();
            float startPointY, xPos, yPos;
          
            // engel aşağıdaysa, engele göre random bir y pozisyonu belirle
            if (obstacleCollider.transform.position.y < 0)
            {
                startPointY = obstacleCollider.transform.position.y + (obstacleCollider.bounds.extents.y*2f) + 1f;
                yPos = Random.Range(startPointY, startPointY + 1.7f);
            }
            // engel yukarıdaysa, engele göre random bir y pozisyonu belirle
            else
            {
                startPointY = obstacleCollider.transform.position.y - obstacleCollider.bounds.size.y - 1f;
                yPos = Random.Range(startPointY - 1.7f, startPointY);
            }
            xPos = obstacleCollider.transform.position.x + Random.Range(-2.5f, 2.5f);
            return new Vector2(xPos, yPos);
        }

    }
}