using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    internal int currentScore;
    internal int bestScore;
    [SerializeField] private TextMeshProUGUI _currentScoreText, _bestScoreText;
    [SerializeField] private Transform _planeTransform;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        _bestScoreText.text = "Best Score: " + bestScore.ToString() + "m";
    }

    private void LateUpdate()
    {
        currentScore = (int)_planeTransform.position.x + 5;
        _currentScoreText.text = currentScore.ToString() + "m";
    }
}
