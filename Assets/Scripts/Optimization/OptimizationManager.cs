using UnityEngine;

namespace Assets.Scripts.Optimization
{
    public class OptimizationManager : MonoBehaviour
    {
        AbstractFPSTuner fPSTuner;
        private void Awake()
        {
            fPSTuner = GetComponent<AbstractFPSTuner>();
            fPSTuner.SetToMaximumFPS();
        }
    }
}