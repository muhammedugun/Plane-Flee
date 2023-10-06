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
    
    /// <summary>
    /// Coin deðerini güncelleyen fonksiyon
    /// </summary>
    public void UpdateCoin()
    {
        if (isScoreMultiplierActive)
            coin += 2;
        else
            coin++;

        UpdateCoinDisplay();
    }

    /// <summary>
    /// Skor görüntüsünü güncelleyen fonksiyon
    /// </summary>
    private void UpdateCoinDisplay()
    {
        string coinString = coin.ToString().PadLeft(3,'0');
        coinText.text = coinString;
    }
}
