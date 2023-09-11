using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    bool isActive = true;
    public float reloadTime = 0.2f;
    public float nextReloadTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (isActive)
        {
            rb.velocity = transform.TransformDirection(new Vector2(speed, 0));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            collision.GetComponent<ObstacleManager>().health--;
            if(collision.GetComponent<ObstacleManager>().health<=0)
            {
                var collAnimator = collision.gameObject.GetComponent<Animator>();
                collAnimator.SetBool("isDestroy", true);
            }
            Stop();

        }
        else if (collision.gameObject.CompareTag("ground"))
        {
            Stop();
        }
    }


    public void Stop()
    {
        gameObject.GetComponent<Animator>().SetBool("isDestroy", true);
        isActive = false;
        rb.velocity = Vector2.zero;
    }

    public void Continue(GameObject bullet)
    {
        bullet.GetComponent<Animator>().SetBool("isDestroy", false);
        isActive = true;
        Active(bullet);
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }

    public void Active(GameObject bullet)
    {
        bullet.SetActive(true);
    }
}