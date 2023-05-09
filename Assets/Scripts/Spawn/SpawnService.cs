using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Spawn
{
    public class SpawnService : MonoBehaviour
    {
        /// <summary>
        /// Spawn dizisindeki objelerin indexlerini düzenler.
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