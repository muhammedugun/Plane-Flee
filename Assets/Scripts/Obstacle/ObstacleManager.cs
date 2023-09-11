
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public int health = 3;

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
