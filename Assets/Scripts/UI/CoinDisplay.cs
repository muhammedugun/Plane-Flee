using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{

    /// <summary>
    /// alt�n de�erini tutan de�i�ken
    /// </summary>
    public int coin = 0;

    /// <summary>
    /// Skor �arpan� aktif mi (2x �arpan)
    /// </summary>
    public bool isScoreMultiplierActive;

    [SerializeField] private TextMeshProUGUI coinText;
    
    private void Start()
    {
        UpdateCoinDisplay();
    }

    /// <summary>
    /// Coin de�erini g�ncelleyen fonksiyon
    /// </summary>
    public void UpdateCoin()
    {
        if (isScoreMultiplierActive)
        {
            coin += 2;
            
        }
            
        else
        {
            coin++;
        }
            
        UpdateCoinDisplay();
    }

    /// <summary>
    /// Skor g�r�nt�s�n� g�ncelleyen fonksiyon
    /// </summary>
    private void UpdateCoinDisplay()
    {
        string coinString = coin.ToString();

        if (coinString.Length==1)
        {
            coinString = "00" + coinString;
        }
        else if(coinString.Length == 2)
        {
            coinString = "0" + coinString;
        }

        coinText.text = coinString;
    }
}
