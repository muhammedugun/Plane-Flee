using Assets.Scripts.Plane;
using UnityEngine;

namespace Assets.Scripts.GameDifficulty
{
    public class SpeedDifficulty : MonoBehaviour
    {
        [SerializeField] PlaneMovement planeMovement;
        [SerializeField] float difficultyDuration;
        float nextDifficultyTime;

        public void StartDifficulty()
        {
            SetNextDifficultyTime();
        }

        public void SetDifficulty()
        {
            if (Time.time >= nextDifficultyTime && planeMovement.horizontalSpeed <= 15f)
            {
                planeMovement.horizontalSpeed += 0.2f;
                SetNextDifficultyTime();
            }

        }

        void SetNextDifficultyTime()
        {
            nextDifficultyTime = Time.time + difficultyDuration;
        }

    }
}