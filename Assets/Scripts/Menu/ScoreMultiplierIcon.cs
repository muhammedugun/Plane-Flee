using UnityEngine;

public class ScoreMultiplierIcon : MonoBehaviour
{
    public float time;
    public ScoreDisplay scoreDisplay;
    public GameObject scoreMultiplier;
    public GameObject planeTransform;

    private float startTime;
    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void LateUpdate()
    {
        if (Time.time >= startTime + time)
        {
            scoreDisplay.isScoreMultiplierActive = false;
            gameObject.SetActive(false);
        }
    }

    [System.Obsolete]
    private void OnDisable()
    {
        Invoke("Respawn", 3f);
        Debug.Log("1  " + planeTransform.transform.position.x);
    }


    private void Respawn()
    {
        scoreMultiplier.gameObject.SetActive(true);
        scoreMultiplier.gameObject.GetComponent<MovementAbility>().xpos = planeTransform.transform.position.x + 10f;
        Debug.Log("2  " + planeTransform.transform.position.x);
    }
}


