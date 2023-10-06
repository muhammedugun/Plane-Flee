using TMPro;
using UnityEngine;

/// <summary>
/// Skoru ekranda göstermekten sorumlu sýnýf
/// </summary>
public class ScoreDisplay : MonoBehaviour
{
    // þuanki skoru
    internal int currentScore;
    // en yüksek skor
    internal int bestScore;
    // þuanki ve en yüksek skoru yazdýrcak olan arayüz objeleri
    [SerializeField] private TextMeshProUGUI _currentScoreText, _bestScoreText;
    // uçaðýn pozisyonunu barýndýran transform
    [SerializeField] private Transform _planeTransform;

    // Oyun baþlar baþlamaz en yüksek skoru arayüze yazýyoruz
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        _bestScoreText.text = "Best Score: " + bestScore.ToString() + "m";
    }

    // Oyun devam ettikçe mevcut skoru arayüze yazýyoruz
    private void LateUpdate()
    {
        currentScore = (int)_planeTransform.position.x + 5;
        _currentScoreText.text = currentScore.ToString() + "m";
    }
}
