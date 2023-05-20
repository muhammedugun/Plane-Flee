using Assets.Scripts.GameObjectService;
using Assets.Scripts.Spawn;
using UnityEngine;

namespace Assets.Scripts.Plane
{
    public class PlaneSmokeAnimation : MonoBehaviour
    {
        [SerializeField] GameObject smokePrefab;
        [SerializeField] Transform planeTransform;
        [SerializeField] int maxSmokeCount;
        GameObject[] smokes;

        private void Awake()
        {
            smokes = new GameObject[maxSmokeCount];
        }
        void Start()
        {
            PlaneMovement.OnFly += SpawnSmoke;
            FirstCreate();
        }

        private void OnDisable()
        {
            PlaneMovement.OnFly -= SpawnSmoke;
        }

        void FirstCreate()
        {
            smokes = CreateObjectService.CreateMultiple(smokePrefab, maxSmokeCount);
            foreach (GameObject obj in smokes)
            {
                obj.transform.position = new Vector2(-20f,20f);
            }
        }

        void SpawnSmoke()
        {
            var smokePos = new Vector2(planeTransform.position.x - 1f, planeTransform.position.y - 0.5f);
            smokes[0].transform.position = smokePos;
            smokes[0].GetComponent<Animator>().SetTrigger("smoke");
            SpawnService.FixSpawnArrayIndexs(ref smokes);
        }


    }
}