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
    
    /// <summary>
    /// Coin de�erini g�ncelleyen fonksiyon
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
    /// Skor g�r�nt�s�n� g�ncelleyen fonksiyon
    /// </summary>
    private void UpdateCoinDisplay()
    {
        string coinString = coin.ToString().PadLeft(3,'0');
        coinText.text = coinString;
    }
}
