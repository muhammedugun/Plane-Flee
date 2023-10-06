using System;
using UnityEngine;

namespace Assets.Scripts.Collection
{
    public class CollectionManager : MonoBehaviour
    {
        /// <summary>
        /// Bir yetenek ile çarpıştığında
        /// </summary>
        public static event Action OnCollectPickup;

        private CoinCollection starCollection;


        private void Awake()
        {
            starCollection = GetComponent<CoinCollection>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (starCollection.Check(collision))
            {
                starCollection.Collect(collision);
            }

            else if(CheckPickup(collision))
            {
                OnCollectPickup.Invoke();
            }

        }

        /// <summary>
        /// Uçak bir yetenek ile çarpıştı mı?
        /// </summary>
        /// <param name="collider"></param>
        /// <returns></returns>
        public bool CheckPickup(Collider2D collision)
        {
            if(collision.CompareTag("pickup"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}