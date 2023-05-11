using UnityEngine;


namespace Assets.Scripts.Background
{
    /// <summary>
    /// Bir arkaplan geçiþ yöntemi olan parallax efekti ile ilgili görevlerden sorumlu
    /// </summary>
    public class ParallaxTransition : AbstractBackgroundTransition
    {
        [SerializeField] Material backgroundMaterial;

        // Arkaplanýn ilerlemiþ olduðu mevcut mesafesi
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

