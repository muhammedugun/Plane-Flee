using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    /// <summary>
    /// Sprite'lar�n tutuldu�u dizi
    /// </summary>
    public Sprite[] digitSprites;
    /// <summary>
    /// Rakamlar�n g�r�nt�lendi�i Image bile�enlerinin dizisi
    /// </summary>
    public Image[] digitImages;

    /// <summary>
    /// Skor de�i�keni
    /// </summary>
    public int score = 0;



    private void Start()
    {
        UpdateScoreDisplay();
    }

    /// <summary>
    /// Skor de�erini g�ncelleyen fonksiyon
    /// </summary>
    /// <param name="value"></param>
    public void UpdateScore()
    {
        score++;
        UpdateScoreDisplay();
    }

    /// <summary>
    /// Skor g�r�nt�s�n� g�ncelleyen fonksiyon
    /// </summary>
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
                digitImages[i].GetComponent<Animator>().SetTrigger("scoreIncreased");
            }
            else
            {
                digitImages[i].enabled = false;
            }
            switch (scoreString.Length)
            {
                case 2:
                    digitImages[0].rectTransform.anchoredPosition = new Vector2(-60f, digitImages[0].rectTransform.anchoredPosition.y);
                    digitImages[1].rectTransform.anchoredPosition = new Vector2(60f, digitImages[1].rectTransform.anchoredPosition.y);
                    break;
                case 3:
                    digitImages[0].rectTransform.anchoredPosition = new Vector2(-120f, digitImages[0].rectTransform.anchoredPosition.y);
                    digitImages[1].rectTransform.anchoredPosition = new Vector2(0f, digitImages[1].rectTransform.anchoredPosition.y);
                    digitImages[2].rectTransform.anchoredPosition = new Vector2(120f, digitImages[2].rectTransform.anchoredPosition.y);
                    break;
                case 4:
                    digitImages[0].rectTransform.anchoredPosition = new Vector2(-180f, digitImages[0].rectTransform.anchoredPosition.y);
                    digitImages[1].rectTransform.anchoredPosition = new Vector2(-60f, digitImages[1].rectTransform.anchoredPosition.y);
                    digitImages[2].rectTransform.anchoredPosition = new Vector2(60f, digitImages[2].rectTransform.anchoredPosition.y);
                    digitImages[3].rectTransform.anchoredPosition = new Vector2(180f, digitImages[3].rectTransform.anchoredPosition.y);
                    break;
                default:
                    break;
            }
        }
    }
}
