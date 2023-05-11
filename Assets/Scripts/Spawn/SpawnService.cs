using UnityEngine;

namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Spawn ile ilgili hizmetleri sağlamaktan sorumlu
    /// </summary>
    public class SpawnService : MonoBehaviour
    {
        /// <summary>
        /// Spawn dizisindeki objelerin indexlerini düzenler. Not: 1 spawn yapıldıktan sonra çağırılmalı
        /// </summary>
        /// <param name="spawnObjects"></param>
        public static void FixSpawnArrayIndexs(ref GameObject[] spawnObjects)
        {
            GameObject[] tempTransforms = new GameObject[spawnObjects.Length];
            for (int i = 0; i < tempTransforms.Length; i++)
            {
                tempTransforms[i] = spawnObjects[i];
            }

            for (int i = 0; i < spawnObjects.Length; i++)
            {
                if (i == spawnObjects.Length - 1)
                {
                    spawnObjects[i] = tempTransforms[0];
                }
                else
                {
                    spawnObjects[i] = tempTransforms[i + 1];
                }
            }
        }

    }
}