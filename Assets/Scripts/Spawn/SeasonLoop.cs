using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Mevsim döngüsü ile ilgili görevlerden sorumlu
    /// </summary>
    /// 
    public class SeasonLoop : MonoBehaviour
    {
        ConsecutiveGroundSpawner consecutiveGroundSpawner;
        public Sprite[] groundSprites;
        public float loopDuration;
        internal float nextLoopTime;
        internal GameObject firstGround;
        /// <summary>
        /// Şuanki mevsimdeki zeminin sprite indeksi
        /// </summary>
        int currentGroundSpriteIndex;
        /// <summary>
        /// Değişen sprite sayısı
        /// </summary>
        int changingGroundSpriteCount;

        private void Awake()
        {
            consecutiveGroundSpawner = GetComponent<ConsecutiveGroundSpawner>();
            
        }
        private void Start()
        {
            changingGroundSpriteCount = consecutiveGroundSpawner.spawnObjects.Length;
            SetNextLoopTime();
        }

    

        public void ChangeGroundSprite()
        {
            if(changingGroundSpriteCount<consecutiveGroundSpawner.spawnObjects.Length)
            {
                changingGroundSpriteCount++;
                firstGround = consecutiveGroundSpawner.spawnObjects[0];
                ChangeSprite(firstGround, groundSprites[currentGroundSpriteIndex]);
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
            
        }


        public void SetCurrentGroundSpriteIndex()
        {
            currentGroundSpriteIndex++;
            if (currentGroundSpriteIndex >= groundSprites.Length)
            {
                currentGroundSpriteIndex = 0;
            }
        }


    }
}