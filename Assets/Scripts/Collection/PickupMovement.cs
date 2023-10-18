using UnityEngine;
using DG.Tweening;

public class PickupMovement : MonoBehaviour
{
    internal float xpos;
    [SerializeField] private Transform planeTransform;
    [SerializeField] private PickupManager pickupManager;
    void Start()
    {
        xpos = gameObject.transform.position.x;
        gameObject.transform.DOMove(new Vector2(gameObject.transform.position.x, 2.5f), 1).SetEase(Ease.InOutSine).
            SetLoops(-1, LoopType.Yoyo);
    }

    private void LateUpdate()
    {
        if (Time.timeScale != 0)
        {
            gameObject.transform.position = new Vector2(xpos, gameObject.transform.position.y);
            xpos -= 0.03f;
        }

        // uçak pickup yemediyse pickupý yeniden spawn et
        if (planeTransform.position.x > transform.position.x + 20f)
        {
            pickupManager.InvokeRespawn();
        }
    }
}