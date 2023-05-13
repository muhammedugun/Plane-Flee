using UnityEngine;

namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Mevsim döngüsü ile ilgili görevlerden sorumlu
    /// </summary>
    public class SeasonLoop : MonoBehaviour
    {
        GroundSpawner groundSpawner;
        ObstacleSpawner obstacleSpawner;
        public Sprite[] groundSprites;
        public Sprite[] obstacleSprites;
        public float loopDuration;
        internal float nextLoopTime;
        /// <summary>
        /// Şuanki mevsimdeki zeminin sprite indeksi
        /// </summary>
        int currentGroundSpriteIndex;
        /// <summary>
        /// zeminin değişen sprite sayısı
        /// </summary>
        int changingGroundSpriteCount;

        /// <summary>
        /// Şuanki mevsimdeki engelin sprite indeksi
        /// </summary>
        int currentObstacleSpriteIndex;
        /// <summary>
        /// engelin değişen sprite sayısı
        /// </summary>
        int changingObstacleSpriteCount;

        private void Awake()
        {
            groundSpawner = GetComponent<GroundSpawner>();
            obstacleSpawner = GetComponent<ObstacleSpawner>();

        }
        private void Start()
        {
            changingGroundSpriteCount = groundSpawner.spawnObjects.Length;
            changingObstacleSpriteCount = obstacleSpawner.spawnObjects.Length;
            SetNextLoopTime();
        }

    

        public void ChangeGroundSprite()
        {
            ChangeObjectSprite(groundSpawner, ref changingGroundSpriteCount, groundSprites, currentGroundSpriteIndex);
        }

        public void ChangeObstacleSprite()
        {
            if (obstacleSpawner.minDistance<2f) 
                ChangeObjectSpriteDouble(obstacleSpawner, ref changingObstacleSpriteCount, obstacleSprites, currentObstacleSpriteIndex);
            else 
                ChangeObjectSprite(obstacleSpawner, ref changingObstacleSpriteCount, obstacleSprites, currentObstacleSpriteIndex);
        }
       

        void ChangeObjectSprite(AbstractSpawner abstractSpawner,ref int changingObjectSpriteCount, Sprite[] objectSprites, int currentObjectSpriteIndex)
        {
            if (changingObjectSpriteCount < abstractSpawner.spawnObjects.Length)
            {
                var firstObject = abstractSpawner.spawnObjects[0];
                ChangeSprite(firstObject, objectSprites[currentObjectSpriteIndex]);
                changingObjectSpriteCount++;
            }

        }

        void ChangeObjectSpriteDouble(AbstractSpawner abstractSpawner, ref int changingObjectSpriteCount, Sprite[] objectSprites, int currentObjectSpriteIndex)
        {
            if (changingObjectSpriteCount < abstractSpawner.spawnObjects.Length)
            {
                var firstObject = abstractSpawner.spawnObjects[0];
                var secondObject = abstractSpawner.spawnObjects[1];
                ChangeSprite(firstObject, objectSprites[currentObjectSpriteIndex]);
                ChangeSprite(secondObject, objectSprites[currentObjectSpriteIndex]);
                changingObjectSpriteCount+=2;
            }

        }

        /// <summary>
        /// Gönderilen objenin sprite'ını değiştirir
        /// </summary>
        public void ChangeSprite(GameObject gameObject, Sprite sprite)
        {
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }
        /// <summary>
        /// sonraki döngünün zamanını ayarlar
        /// </summary>
        public void SetNextLoopTime()
        {
            nextLoopTime += loopDuration;
            changingGroundSpriteCount = 0;
            changingObstacleSpriteCount = 0;
            
        }


        public void SetCurrentGroundSpriteIndex()
        {
            SetCurrentSeasonSpriteIndex(ref currentGroundSpriteIndex, groundSprites);
        }

        public void SetCurrentObstacleSpriteIndex()
        {
            
            if(currentGroundSpriteIndex==3 || currentGroundSpriteIndex == 0)
            {
                currentObstacleSpriteIndex = 0;
            }
            else
            {
                currentObstacleSpriteIndex++;
            }
            
        }


        void SetCurrentSeasonSpriteIndex(ref int currentSeasonSpriteIndex, Sprite[] seasonSprites)
        {
            currentSeasonSpriteIndex++;
            if (currentSeasonSpriteIndex >= seasonSprites.Length)
            {
                currentSeasonSpriteIndex = 0;
            }
        }

    }
}