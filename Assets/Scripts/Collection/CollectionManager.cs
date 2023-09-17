using Assets.Scripts.Plane.ObserverPattern;
using UnityEngine;

namespace Assets.Scripts.Collection
{
    public class CollectionManager : MonoBehaviour
    {
        public TriggerSubject triggerSubject;
        public ScoreDisplay scoreDisplay;
        public GameObject scoreMultiplierIcon, shield;
        private StarCollection starCollection;
        private void Awake()
        {
            starCollection = GetComponent<StarCollection>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (starCollection.Check(collision))
            {
                starCollection.Collect(collision);
            }

            else if(CheckScoreMultiplier(collision))
            {
                scoreDisplay.isScoreMultiplierActive = true;
                scoreMultiplierIcon.SetActive(true);
            }

            else if (CheckShield(collision))
            {
                triggerSubject.isShieldActive = true;
                shield.SetActive(true);
            }
        }

        /// <summary>
        /// Uçak skor çarpanıyla çarpıştı mı?
        /// </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public bool CheckScoreMultiplier(Collider2D collider)
        {
            if (collider.name == "Score Multiplier Pickup")
            {
                collider.gameObject.SetActive(false);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Uçak skor çarpanıyla çarpıştı mı?
        /// </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public bool CheckShield(Collider2D collider)
        {
            if (collider.name == "Shield Pickup")
            {
                collider.gameObject.SetActive(false);
                return true;
            }
            else
                return false;
        }
    }
}