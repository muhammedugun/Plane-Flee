
namespace Assets.Scripts.SeasonLoop
{
    public class GroundSeasonLoop : AbstractSeasonLoop
    {

        private void Awake()
        {
            currentObjectSpriteIndex = 0;
        }

        private void Start()
        {
            changingObjectSpriteCount = spawner.spawnObjects.Length;
        }

        
    }
}