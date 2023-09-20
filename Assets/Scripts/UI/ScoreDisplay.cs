using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    internal int currentScore;
    internal int bestScore;
    [SerializeField] private TextMeshProUGUI currentScoreText, bestScoreText;
    [SerializeField] Transform planeTransform;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestScoreText.text = bestScore.ToString() + "m";
    }

    private void LateUpdate()
    {
        currentScore = (int)planeTransform.position.x + 5;
        currentScoreText.text = currentScore.ToString() + "m";
    }
}
