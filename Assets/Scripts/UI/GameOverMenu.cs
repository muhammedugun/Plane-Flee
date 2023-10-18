using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI currentScoreText;
        [SerializeField] TextMeshProUGUI bestScoreText;
        [SerializeField] TextMeshProUGUI currentCoinCountText;

        void Start()
        {

            currentScoreText.text = "Current Score: " + PlayerPrefs.GetInt("currentScore").ToString();
            bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("bestScore").ToString();
            currentCoinCountText.text = "Coin: " + PlayerPrefs.GetInt("currentCoinCount").ToString();
        }
    }
}