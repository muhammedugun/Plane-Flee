﻿using Assets.Scripts.Plane;
using UnityEngine;

namespace Assets.Scripts.Background
{
    /// <summary>
    /// Arkaplan ile ilgili görevleri yönetir. Bu scriptin olduğu objede IBackgroundTransition arayüzüne sahip component eklenmeli
    /// </summary>
    public class BackgroundManager : MonoBehaviour
    {
        [SerializeField] PlaneManager planeManager;
        ParallaxTransition backgroundTransition;

        //public float testSpeed;

        private void Awake()
        {
            backgroundTransition = GetComponent<ParallaxTransition>();
        }

        void Update()
        {
            backgroundTransition.AdvanceWithReferanceSpeed(planeManager.planeMovement.horizontalSpeed);
        }
    }
}