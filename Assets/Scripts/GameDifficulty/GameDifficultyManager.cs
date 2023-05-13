using UnityEngine;

namespace Assets.Scripts.GameDifficulty
{
    public class GameDifficultyManager : MonoBehaviour
    {
        SpawnDifficulty spawnDifficulty;
        SpeedDifficulty speedDifficulty;

        private void Awake()
        {
            spawnDifficulty = GetComponent<SpawnDifficulty>();
            speedDifficulty = GetComponent<SpeedDifficulty>();
        }

        private void Start()
        {
            spawnDifficulty.StartDifficulty();
            speedDifficulty.StartDifficulty();
        }

        private void LateUpdate()
        {
            spawnDifficulty.SetDifficulty();
            speedDifficulty.SetDifficulty();
        }

    }
}