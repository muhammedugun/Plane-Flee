using UnityEngine;


namespace Assets.Scripts.Background
{
    /// <summary>
    /// Bir arkaplan ge�i� y�ntemi olan parallax efekti ile ilgili g�revlerden sorumlu
    /// </summary>
    public class ParallaxTransition : MonoBehaviour, IBackgroundTransition
    {
        public float Speed { get { return speed; } set { speed = value; } }
        [SerializeField] Material backgroundMaterial;

        // Arkaplan�n ilerlemi� oldu�u mevcut mesafesi
        float currentDistance;


        [Range(0f, 0.1f)]
        [SerializeField] float speed = 0.01f;

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

