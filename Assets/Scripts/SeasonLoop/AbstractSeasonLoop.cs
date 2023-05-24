using Assets.Scripts.Spawn;
using UnityEngine;

namespace Assets.Scripts.SeasonLoop
{
    /// <summary>
    /// Mevsim döngüsü ile ilgili görevlerden sorumlu
    /// </summary>
    public abstract class AbstractSeasonLoop : MonoBehaviour
    {
        public AbstractSpawner spawner;

        public Sprite[] objectSprites;

        /// <summary>
        /// mevcut objelerden değişen sprite sayısı
        /// </summary>
        public int changingObjectSpriteCount;

        /// <summary>
        /// Şuanki mevsimin sprite indeksi
        /// </summary>
        public int currentObjectSpriteIndex;

        /// <summary>
        /// objectSprites dizisinin başındaki objenin sprite'ını mevcut mevsime göre değiştirir
        /// </summary>
        public virtual void ChangeSprite()
        {
            if (changingObjectSpriteCount < spawner.spawnObjects.Length)
            {
                var firstObject = spawner.spawnObjects[0];
                SetSprite(firstObject, objectSprites[currentObjectSpriteIndex]);
                changingObjectSpriteCount++;
            }
        }

        /// <summary>
        /// Gönderilen objenin sprite'ını değiştirir
        /// </summary>
        public void SetSprite(GameObject gameObject, Sprite sprite)
        {
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }

        

        /// <summary>
        /// mevcut objelerin değişen sprite sayısını sıfırlar
        /// </summary>
        public void ResetSpriteCount()
        {
            changingObjectSpriteCount = 0;
        }


        /// <summary>
        /// Mevsimi değiştirir
        /// </summary>
        public void ChangeSeason()
        {
            currentObjectSpriteIndex++;
            if (currentObjectSpriteIndex >= objectSprites.Length)
            {
                currentObjectSpriteIndex = 0;
            }
        }


    }
}