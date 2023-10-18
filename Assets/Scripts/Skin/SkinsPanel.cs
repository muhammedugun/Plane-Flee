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
    /// Satýnalýmlarý günceller
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
    ///  Kaplamanýn daha önce satýnalýnmýþ olmasýný kontrol eder.
    /// </summary>
    /// <returns>Satýnalýnmýþsa True döndürür</returns>
    private bool CheckPurchase(int index)
    {
        if (PlayerPrefs.GetInt("skinID_" + index.ToString()) == 1) return true;
        else return false;
    }

    public void BuySkin(int index)
    {
        if (!CheckPurchase(index))
        {
            // Altýn sayýmýz kaplamayý almaya yetiyor mu?
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
