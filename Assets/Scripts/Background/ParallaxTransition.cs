using UnityEngine;


namespace Assets.Scripts.Background
{
    /// <summary>
    /// Bir arkaplan geçiþ yöntemi olan parallax efekti ile ilgili görevlerden sorumlu
    /// </summary>
    public class ParallaxTransition : MonoBehaviour
    {

        [Range(0f, 0.2f)]
        public float speed;
        public Material[] materialArray;

        // Arkaplanýn ilerlemiþ olduðu mevcut mesafesi
        float currentDistance;

        [System.Obsolete]
        private void Start()
        {
            RandomMaterial();

        }

        [System.Obsolete]
        private void RandomMaterial()
        {
            int materialCount = materialArray.Length;
            int randomIndex = Random.RandomRange(0, materialCount + 1);
            GetComponent<MeshRenderer>().material = materialArray[randomIndex];
        }

        public void AdvanceWithReferanceSpeed(float referanceSpeed)
        {
            
            Advance(speed*referanceSpeed);
        }

        public void Advance(float speed)
        {
            currentDistance += Time.deltaTime * speed;
            GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", Vector2.right * currentDistance);
        }
        
    }
}

