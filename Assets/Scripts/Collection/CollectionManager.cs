using UnityEngine;

namespace Assets.Scripts.Collection
{
    public class CollectionManager : MonoBehaviour
    {
        StarCollection starCollection;
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
        }
    }
}