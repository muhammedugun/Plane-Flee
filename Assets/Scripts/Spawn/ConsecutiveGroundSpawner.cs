using Assets.Scripts.GameObjectService;
using Assets.Scripts.Plane.ObserverDesign;
using UnityEngine;
using static UnityEditor.Progress;


namespace Assets.Scripts.Spawn
{
    /// <summary>
    /// Sıralı şekilde zemin oluşturma ile ilgili görevlerden sorumlu
    /// </summary>
    public class ConsecutiveGroundSpawner : MonoBehaviour, IConsecutiveObjectSpawner
    {
        public GameObject SpawnObjectPrefab { get { return spawnObjectPrefab; } set { spawnObjectPrefab = value; }  }
        [SerializeField] GameObject spawnObjectPrefab;
        public GameObject[] SpawnObjects { get { return spawnObjects; } set { spawnObjects = value; } }
        GameObject[] spawnObjects = new GameObject[4];

        public Transform SpawnStartPoint { get { return spawnStartPoint; } set { spawnStartPoint = value; } }


        [SerializeField] Transform spawnStartPoint;
        
        /// <summary>
        /// son zeminin pozisyonu
        /// </summary>
        public static Transform finalGroundPosition;

        private void Awake()
        {
            finalGroundPosition = spawnStartPoint;
        }

        public void SpawnFirst()
        {
            spawnObjects = CreateObjectService.CreateMultiple(spawnObjectPrefab, 4);
            float groundWidth = ObjectPhysicalInfoService.FindWidth(SpawnObjects[0].GetComponent<Collider2D>());
            MoveForwardMultiple(ref spawnStartPoint, spawnObjects, groundWidth);
        }

        public void SpawnContinuously()
        {
            float groundWidth = ObjectPhysicalInfoService.FindWidth(spawnObjects[0].GetComponent<Collider2D>());
            MoveForward(ref finalGroundPosition, spawnObjects[0], groundWidth);
            SpawnService.FixSpawnArrayIndexs(ref spawnObjects);
            SetFinalGround();
        }


        public void MoveForward(ref Transform lastGround, GameObject ground, float groundWidth)
        {
            var spawnPositionX = lastGround.position.x + groundWidth;
            ground.transform.position = new Vector2(spawnPositionX, -5f);
            lastGround = ground.transform;
        }

        public void MoveForwardMultiple(ref Transform lastGround, GameObject[] grounds, float groundWidth)
        {
            for (int i = 0; i < grounds.Length; i++)
            {
                Debug.Log("lastGround.position: " + lastGround.position);
                MoveForward(ref lastGround, grounds[i], groundWidth);
            }
        }


        public void SetFinalGround()
        {
            finalGroundPosition = spawnObjects[spawnObjects.Length - 1].transform;
        }

       
    }
}