using UnityEngine;

namespace Assets.Scripts.Optimization
{
    public class OptimizationManager : MonoBehaviour
    {
        MobileFPSTuner fPSTuner;
        private void Awake()
        {
            fPSTuner = GetComponent<MobileFPSTuner>();
            fPSTuner.SetToMaximumFPS();
        }
    }
}