using Assets.Scripts.Spawn;

namespace Assets.Scripts.SeasonLoop
{
    public class ObstacleSeasonLoop : AbstractSeasonLoop
    {
        private void Awake()
        {
            currentObjectSpriteIndex = 0;
        }

        private void Start()
        {
            changingObjectSpriteCount = spawner.spawnObjects.Length;
        }

        public override void ChangeSprite()
        {
            if ((spawner as ObstacleSpawner).minDistance < 2f)
                ChangeObjectSpriteDouble();
            else
                base.ChangeSprite();

        }

        void ChangeObjectSpriteDouble()
        {
            if (changingObjectSpriteCount < spawner.spawnObjects.Length)
            {
                var firstObject = spawner.spawnObjects[0];
                var secondObject = spawner.spawnObjects[1];
                SetSprite(firstObject, objectSprites[currentObjectSpriteIndex]);
                SetSprite(secondObject, objectSprites[currentObjectSpriteIndex]);
                changingObjectSpriteCount += 2;
            }

        }
    }
}