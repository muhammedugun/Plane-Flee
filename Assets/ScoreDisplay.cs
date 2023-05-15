using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Sprite[] digitSprites; // Sprite'lar�n tutuldu�u dizi
    public Image[] digitImages; // Rakamlar�n g�r�nt�lendi�i Image bile�enlerinin dizisi

    private int score = 0; // Skor de�i�keni

    private void Start()
    {
        UpdateScoreDisplay(); // Skor g�r�nt�s�n� g�ncelle
    }

    // Skor de�erini g�ncelleyen fonksiyon
    public void UpdateScore(int value)
    {
        score += value;
        UpdateScoreDisplay();
    }

    // Skor g�r�nt�s�n� g�ncelleyen fonksiyon
    private void UpdateScoreDisplay()
    {
        string scoreString = score.ToString();

        // Skorun her bir hanesini dola�
        for (int i = 0; i < digitImages.Length; i++)
        {
            if (i < scoreString.Length)
            {
                int digit = int.Parse(scoreString[i].ToString());
                digitImages[i].sprite = digitSprites[digit];
                digitImages[i].enabled = true;
            }
            else
            {
                digitImages[i].enabled = false;
            }
        }
    }
}
