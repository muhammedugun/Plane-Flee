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
        [SerializeField] Material backgroundMaterial;

        // Arkaplan�n ilerlemi� oldu�u mevcut mesafesi
        float currentDistance;


        public void AdvanceWithReferanceSpeed(float referanceSpeed)
        {
            
            Advance(speed*referanceSpeed);
        }

        public void Advance(float speed)
        {
            currentDistance += Time.deltaTime * speed;
            backgroundMaterial.SetTextureOffset("_MainTex", Vector2.right * currentDistance);
        }
        
    }
}

