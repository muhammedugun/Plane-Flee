using TMPro;
using UnityEngine;

public class SkinsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private TextMeshProUGUI _coinCountText;
    [SerializeField] private SkinManager _skinmanager;
    [SerializeField] private int[] _prices;
    private GameObject[] _skins;

    void Start()
    {
        _skins = new GameObject[_container.transform.childCount];

        for (int i = 0; i < _skins.Length; i++)
        {
            _skins[i] = _container.transform.GetChild(i).gameObject;
        }
        SetPrices();
        UpdatePurchases();
        UpdateCheckMark();

    }


    private void SetPrices()
    {
        for (int i = 0; i < _skins.Length; i++)
        {
            _skins[i].transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _prices[i].ToString();
        }
    }

    /// <summary>
    /// Sat�nal�mlar� g�nceller
    /// </summary>
    private void UpdatePurchases()
    {
        for (int i = 0; i < _skins.Length; i++)
        {
            if (CheckPurchase(i))
            {
                _skins[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }

    }

    /// <summary>
    ///  Kaplaman�n daha �nce sat�nal�nm�� olmas�n� kontrol eder.
    /// </summary>
    /// <returns>Sat�nal�nm��sa True d�nd�r�r</returns>
    private bool CheckPurchase(int index)
    {
        if (PlayerPrefs.GetInt("skinID_" + index.ToString()) == 1) return true;
        else return false;
    }

    public void BuySkin(int index)
    {
        if (!CheckPurchase(index))
        {
            // Alt�n say�m�z kaplamay� almaya yetiyor mu?
            if (PlayerPrefs.GetInt("coinCount") >= _prices[index])
            {
                PlayerPrefs.SetInt("skinID_" + index.ToString(), 1);
                PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - _prices[index]);
                PlayerPrefs.SetInt("checkMarkIndex", index);

                UpdatePurchases();
                UpdateCheckMark();
                _coinCountText.GetComponent<CoinUpdater>().UpdateCoin();
                PlayerPrefs.Save();
                _skinmanager.UpdateSkinOnPlane();
            }
        }
        else
        {
            PlayerPrefs.SetInt("checkMarkIndex", index);
            UpdateCheckMark();
            _skinmanager.UpdateSkinOnPlane();
        }
    }

    private void UpdateCheckMark()
    {
        for (int i = 0; i < _skins.Length; i++)
        {
            _skins[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        }
        int checkMarkIndex = PlayerPrefs.GetInt("checkMarkIndex");
        _skins[checkMarkIndex].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
    }
}
