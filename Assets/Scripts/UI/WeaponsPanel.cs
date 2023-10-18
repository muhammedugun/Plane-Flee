using TMPro;
using UnityEngine;

public class WeaponsPanel : MonoBehaviour
{
    [SerializeField] private UIWeaponManager _uIWeaponManager;
    [SerializeField] private TextMeshProUGUI _bulletCountText, _rocketCountText, _coinCountText;
    [SerializeField] private TextMeshProUGUI _bulletPrice, _rocketPrice;


    private void OnEnable()
    {
        UpdateWeaponCountText(_bulletCountText, "bulletCount");
        UpdateWeaponCountText(_rocketCountText, "rocketCount");
    }

    private void OnDisable()
    {
        _uIWeaponManager.UpdateChangeWeaponText();
    }

    public void BuyWeapon(TextMeshProUGUI weaponPriceText, string weaponCountKey)
    {
        // Altýn sayýmýz mühimmatý almaya yetiyor mu?
        if (PlayerPrefs.GetInt("coinCount") >= int.Parse(weaponPriceText.text))
        {
            PlayerPrefs.SetInt(weaponCountKey, PlayerPrefs.GetInt(weaponCountKey) + 1);
            PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - int.Parse(weaponPriceText.text));
            PlayerPrefs.Save();

            UpdateWeaponCountText(_bulletCountText, weaponCountKey);
            UpdateWeaponCountText(_coinCountText, "coinCount");
        }
    }

    public void BuyBullet()
    {
        BuyWeapon(_bulletPrice, "bulletCount");
    }

    public void BuyRocket()
    {
        BuyWeapon(_rocketPrice, "rocketCount");
    }

    private void UpdateWeaponCountText(TextMeshProUGUI weaponCountText, string weaponCountKey)
    {
        weaponCountText.text = PlayerPrefs.GetInt(weaponCountKey).ToString();
    }
}
