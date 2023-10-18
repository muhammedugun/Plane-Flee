using TMPro;
using UnityEngine;

public class CoinUpdater : MonoBehaviour
{
    private TextMeshProUGUI _coinCountText;

    private void Awake()
    {
        _coinCountText = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        UpdateCoin();
    }

    internal void UpdateCoin()
    {

        _coinCountText.text = PlayerPrefs.GetInt("coinCount").ToString();
    }
}
