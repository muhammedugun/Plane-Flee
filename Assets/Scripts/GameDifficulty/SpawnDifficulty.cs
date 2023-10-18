using Assets.Scripts.Spawn;
using UnityEngine;

namespace Assets.Scripts.GameDifficulty
{

    public class SpawnDifficulty : MonoBehaviour
    {
        [SerializeField] ObstacleSpawner obstacleSpawner;
        [SerializeField] float difficultyDuration;
        float nextDifficultyTime;
        bool isSetHeight;

        public void StartDifficulty()
        {
            SetNextDifficultyTime();
        }

        public void SetDifficulty()
        {
            // Zorluğu arttırma döngüsüne ulaşıldığında ve engeller arasındaki minimum 
            // mesafeye henüz ulaşılmadıysa
            if (Time.time >= nextDifficultyTime && obstacleSpawner.minDistance > 4f)
            {
                // engelleri birbirine yakınlaştır
                obstacleSpawner.minDistance -= 0.2f;
                obstacleSpawner.maxDistance -= 0.2f;
                if (obstacleSpawner.minDistance <= 6f && !isSetHeight)
                {
                    obstacleSpawner.topMinHeight += 1f;
                    obstacleSpawner.topMaxHeight += 1f;

                    obstacleSpawner.bottomMaxHeight -= 1f;
                    obstacleSpawner.bottomMinHeight -= 1f;
                    isSetHeight = true;
                }
                // bir sonraki zorluk arttışı için zamanı ayarla
                SetNextDifficultyTime();
            }
        }

        void SetNextDifficultyTime()
        {
            nextDifficultyTime = Time.time + difficultyDuration;
        }
    }
}