using UnityEngine;
using DG.Tweening;

public class MovementAbility : MonoBehaviour
{
    internal float xpos;

    void Start()
    {
        xpos = gameObject.transform.position.x;
        gameObject.transform.DOMove(new Vector2(gameObject.transform.position.x, 3), 1).SetEase(Ease.InOutSine).
            SetLoops(-1, LoopType.Yoyo);
    }


    private void LateUpdate()
    {
        gameObject.transform.position = new Vector2(xpos, gameObject.transform.position.y);
        xpos -= 0.03f;
    }
}
    
