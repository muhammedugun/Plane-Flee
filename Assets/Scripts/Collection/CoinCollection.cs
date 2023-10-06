using System;
using UnityEngine;

namespace Assets.Scripts.Collection
{
    public class CoinCollection : MonoBehaviour
    {
        public static event Action OnCollectStar;

        public CoinDisplay scoreDisplay;
        public bool Check(Collider2D collision)
        {
            if (collision.CompareTag("coin"))
                return true;
            else 
                return false;
        }

        public void Collect(Collider2D collision)
        {
            var animator = collision.GetComponent<Animator>();
            animator.SetTrigger("collect");
            OnCollectStar.Invoke();
        }
    }
}