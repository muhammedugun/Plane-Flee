using UnityEngine;


namespace Assets.Scripts.Background
{
    /// <summary>
    /// Bir arkaplan ge�i� y�ntemi olan parallax efekti ile ilgili g�revlerden sorumlu
    /// </summary>
    public class ParallaxTransition : MonoBehaviour
    {

        [Range(0f, 0.2f)]
        public float speed;
        public Material[] materialArray;

        // Arkaplan�n ilerlemi� oldu�u mevcut mesafesi
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

