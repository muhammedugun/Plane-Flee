using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class GameOverMenu : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI highestScoreTMP;
        [SerializeField] TextMeshProUGUI currentScoreTMP;

        
        void Start()
        {
            highestScoreTMP.text = "Highest Score: " + PlayerPrefs.GetInt("highestScore").ToString();
            currentScoreTMP.text = "Current Score: " + PlayerPrefs.GetInt("currentScore").ToString();

        }

        
    }
}