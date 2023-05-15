using UnityEngine;

namespace Assets.Scripts.Star
{
    public class InteractiveManager : MonoBehaviour
    {
        public void SetDisable()
        {
            Debug.Log("SetDisable");
            gameObject.SetActive(false);
        }
    }
}