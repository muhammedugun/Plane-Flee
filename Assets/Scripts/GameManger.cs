using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManger : MonoBehaviour
{
    [HideInInspector]public float PlayerCoins;
    [HideInInspector]public bool hasRemovedAds;
    [SerializeField]private TMP_Text PlayerCoinsDislay;
    [SerializeField]private TMP_Text AdsRemoved;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCoins = PlayerPrefs.GetFloat("PlayerCoins");
        int boolValue = PlayerPrefs.GetInt("boolValue");
        if (boolValue == 1)
        {
            //Player Has Removed Ads
            hasRemovedAds = true;
            AdsRemoved.text = "AdsRemoved";
        }else
        {
            hasRemovedAds = false;
            AdsRemoved.text = "AdsNotRemoved";
        }

        PlayerCoinsDislay.text = ": " + PlayerCoins.ToString();
    }

    public void GetReward(int coinsAmount, bool isAds)
    {
        if (!isAds)
        {
            PlayerCoins += coinsAmount;
            PlayerPrefs.SetFloat("PlayerCoins", PlayerCoins);
            PlayerCoinsDislay.text = ": " + PlayerCoins.ToString();
            PlayerPrefs.Save();
        }else
        {
            PlayerPrefs.SetInt("boolValue", 1);

            int boolValue = 1;
            if (boolValue == 1)
            {
                //Player Has Removed Ads
                hasRemovedAds = true;
                AdsRemoved.text = "AdsRemoved";
            }else
            {
                hasRemovedAds = false;
                AdsRemoved.text = "AdsNotRemoved";
            }
        }
    }
}
