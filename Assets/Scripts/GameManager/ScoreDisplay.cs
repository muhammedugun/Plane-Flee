using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    /// <summary>
    /// Sprite'ların tutulduğu dizi
    /// </summary>
    public Sprite[] digitSprites;
    /// <summary>
    /// Rakamların görüntülendiği Image bileşenlerinin dizisi
    /// </summary>
    public Image[] digitImages;

    /// <summary>
    /// Skor değişkeni
    /// </summary>
    public int score = 0;



    private void Start()
    {
        UpdateScoreDisplay();
    }

    /// <summary>
    /// Skor değerini güncelleyen fonksiyon
    /// </summary>
    /// <param name="value"></param>
    public void UpdateScore()
    {
        score++;
        UpdateScoreDisplay();
    }

    /// <summary>
    /// Skor görüntüsünü güncelleyen fonksiyon
    /// </summary>
    private void UpdateScoreDisplay()
    {
        string scoreString = score.ToString();

        // Skorun her bir hanesini dolaş
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
