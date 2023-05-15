using Assets.Scripts.Spawn;
using UnityEngine;

namespace Assets.Scripts.SeasonLoop
{
    public class SeasonLoopManager : MonoBehaviour
    {
        internal AbstractSeasonLoop[] seasonLoops;

        public float loopDuration;
        internal float nextLoopTime;

        private void Awake()
        {
            seasonLoops = GetComponents<AbstractSeasonLoop>();
        }

        private void Start()
        {
            SetNextLoopTime();
            foreach (var seasonLoop in seasonLoops)
            {
                seasonLoop.ResetSpriteCount();
            }

        }

        /// <summary>
        /// sonraki döngünün zamanını ayarlar
        /// </summary>
        public void SetNextLoopTime()
        {
            nextLoopTime += loopDuration;
        }

    }
}