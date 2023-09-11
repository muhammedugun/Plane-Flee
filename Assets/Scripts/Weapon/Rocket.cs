using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    bool isActive=true;
    public float reloadTime=5f;
    public float nextReloadTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(isActive)
        {
            rb.velocity = transform.TransformDirection(new Vector2(speed, 0));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            var collAnimator = collision.gameObject.GetComponent<Animator>();
            collAnimator.SetBool("isDestroy", true);
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

    public void Continue()
    {
        gameObject.GetComponent<Animator>().SetBool("isDestroy", false);
        isActive = true;
        Active();
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }

}
