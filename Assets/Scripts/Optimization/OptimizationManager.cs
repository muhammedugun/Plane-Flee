using UnityEngine;

namespace Assets.Scripts.Optimization
{
    public class OptimizationManager : MonoBehaviour
    {
        AbstractFPSTuner fPSTuner;
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            fPSTuner = GetComponent<AbstractFPSTuner>();
            fPSTuner.SetToMaximumFPS();
            
        }


        
    }
}