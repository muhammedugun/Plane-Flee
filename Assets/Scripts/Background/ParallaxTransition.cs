using UnityEngine;


namespace Assets.Scripts.Background
{
    /// <summary>
    /// Bir arkaplan ge�i� y�ntemi olan parallax efekti ile ilgili g�revlerden sorumlu
    /// </summary>
    public class ParallaxTransition : AbstractBackgroundTransition
    {
        [SerializeField] Material backgroundMaterial;

        // Arkaplan�n ilerlemi� oldu�u mevcut mesafesi
        float currentDistance;


        public override void AdvanceWithReferanceSpeed(float referanceSpeed)
        {
            
            Advance(speed*referanceSpeed);
        }

        public override void Advance(float speed)
        {
            currentDistance += Time.deltaTime * speed;
            backgroundMaterial.SetTextureOffset("_MainTex", Vector2.right * currentDistance);
        }

    }
}

