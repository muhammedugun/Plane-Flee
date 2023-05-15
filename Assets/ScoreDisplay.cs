using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Sprite[] digitSprites; // Sprite'larýn tutulduðu dizi
    public Image[] digitImages; // Rakamlarýn görüntülendiði Image bileþenlerinin dizisi

    private int score = 0; // Skor deðiþkeni

    private void Start()
    {
        UpdateScoreDisplay(); // Skor görüntüsünü güncelle
    }

    // Skor deðerini güncelleyen fonksiyon
    public void UpdateScore(int value)
    {
        score += value;
        UpdateScoreDisplay();
    }

    // Skor görüntüsünü güncelleyen fonksiyon
    private void UpdateScoreDisplay()
    {
        string scoreString = score.ToString();

        // Skorun her bir hanesini dolaþ
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
