using System;
using UnityEngine;

namespace Assets.Scripts.Collection
{
    public class StarCollection : MonoBehaviour
    {
        
        public static event Action OnCollectStar;

        public ScoreDisplay scoreDisplay;
        public bool Check(Collider2D collision)
        {
            if (collision.CompareTag("star"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Collect(Collider2D collision)
        {
            var animator = collision.GetComponent<Animator>();
            animator.SetTrigger("collect");
            OnCollectStar.Invoke();
        }

        
    }
}