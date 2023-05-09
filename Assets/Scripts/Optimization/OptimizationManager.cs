using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Optimization
{
    public class OptimizationManager : MonoBehaviour
    {
        IFPSTuner fPSTuner;
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            fPSTuner = GetComponent<IFPSTuner>();
            fPSTuner.SetToMaximumFPS();
            
        }


        
    }
}