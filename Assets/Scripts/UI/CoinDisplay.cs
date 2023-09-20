using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{

    /// <summary>
    /// altýn deðerini tutan deðiþken
    /// </summary>
    public int coin = 0;

    /// <summary>
    /// Skor çarpaný aktif mi (2x çarpan)
    /// </summary>
    public bool isScoreMultiplierActive;

    [SerializeField] private TextMeshProUGUI coinText;
    
    private void Start()
    {
        UpdateCoinDisplay();
    }

    /// <summary>
    /// Coin deðerini güncelleyen fonksiyon
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
    /// Skor görüntüsünü güncelleyen fonksiyon
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
