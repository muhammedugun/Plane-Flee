using TMPro;
using UnityEngine;

/// <summary>
/// Skoru ekranda g�stermekten sorumlu s�n�f
/// </summary>
public class ScoreDisplay : MonoBehaviour
{
    // �uanki skoru
    internal int currentScore;
    // en y�ksek skor
    internal int bestScore;
    // �uanki ve en y�ksek skoru yazd�rcak olan aray�z objeleri
    [SerializeField] private TextMeshProUGUI _currentScoreText, _bestScoreText;
    // u�a��n pozisyonunu bar�nd�ran transform
    [SerializeField] private Transform _planeTransform;

    // Oyun ba�lar ba�lamaz en y�ksek skoru aray�ze yaz�yoruz
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        _bestScoreText.text = "Best Score: " + bestScore.ToString() + "m";
    }

    // Oyun devam ettik�e mevcut skoru aray�ze yaz�yoruz
    private void LateUpdate()
    {
        currentScore = (int)_planeTransform.position.x + 5;
        _currentScoreText.text = currentScore.ToString() + "m";
    }
}
