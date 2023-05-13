using UnityEngine;

namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Spawn ile ilgili görevleri yönetmekten sorumlu. Not: Bulunduğu objede AbstractSpawner'in alt sınıflarından olan en az bir komponent bulunmalı
    /// </summary>
    public class SpawnManager : MonoBehaviour
    {
        AbstractSpawner[] abstractSpawners;

        private void Awake()
        {
            abstractSpawners = GetComponents<AbstractSpawner>();
        }

        private void OnEnable()
        {
            foreach (var item in abstractSpawners)
            {
                item.SpawnFirst();
            }
        }
        

    }
}