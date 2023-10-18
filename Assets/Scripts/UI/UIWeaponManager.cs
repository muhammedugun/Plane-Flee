using Assets.Scripts.Weapon;
using TMPro;
using UnityEngine;

public class UIWeaponManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _changeWeaponText;
    [SerializeField] private WeaponManager _weaponManager;

    private void Start()
    {
        UpdateChangeWeaponText();
    }

    internal void UpdateChangeWeaponText()
    {
        switch (_weaponManager.weaponNo)
        {
            // bullet ise
            case 0:
                _changeWeaponText.text = PlayerPrefs.GetInt("bulletCount").ToString();
                break;
            // rocket ise
            case 1:
                _changeWeaponText.text = PlayerPrefs.GetInt("rocketCount").ToString();
                break;
            default:
                break;
        }
    }
}
