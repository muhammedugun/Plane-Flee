using UnityEngine;

namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Spawn ile ilgili görevleri yönetmekten sorumlu. Not: Bulunduğu objede AbstractSpawner'in alt sınıflarından olan en az bir komponent bulunmalı
    /// </summary>
    public class SpawnManager : MonoBehaviour
    {
        AbstractSpawner[] consecutiveObjectSpawners;

        private void Awake()
        {
            consecutiveObjectSpawners = GetComponents<ConsecutiveGroundSpawner>();
        }

        private void OnEnable()
        {
            foreach (var item in consecutiveObjectSpawners)
            {
                item.SpawnFirst();
            }
        }
        

    }
}