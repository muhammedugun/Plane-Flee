
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public int health = 3;

    public void Deactive()
    {
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("isDestroy", false);
        health = 3;
    }
}
