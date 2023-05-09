using UnityEngine;
// Uçak bir hedefe vardığında bildirimde bulunması ve spawn olunca da yeni bir hedef belirlenmesi yönünde kod refactor edilecek. Herkesin tek bir sorumluluğu olmalı
namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Spawn ile ilgili görevleri yönetmekten sorumlu
    /// </summary>
    public class SpawnManager : MonoBehaviour
    {
        IConsecutiveObjectSpawner[] consecutiveObjectSpawners;

        private void Start()
        {
            consecutiveObjectSpawners = GetComponents<IConsecutiveObjectSpawner>();
            foreach (var item in consecutiveObjectSpawners)
            {
                item.SpawnFirst();
            }
        }

    }
}