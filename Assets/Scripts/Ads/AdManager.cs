using GoogleMobileAds.Api;
using UnityEngine;

namespace Assets.Scripts.Ads
{
    public class AdManager : MonoBehaviour
    {
        public int bannerX, bannerY;
        public static MyRewardedAd rewardedAd;
        MyBannerAd bannerAd;
        private static AdManager instance;

        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                bannerAd = new MyBannerAd();
                rewardedAd = new MyRewardedAd();
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        public void Start()
        {
            // When true all events raised by GoogleMobileAds will be raised
            // on the Unity main thread. The default value is false.
            MobileAds.RaiseAdEventsOnUnityMainThread = true;

            // Initialize the Google Mobile Ads SDK.
            //MobileAds.Initialize(initStatus => { });

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                
            });

            RequestConfiguration requestConfiguration = new RequestConfiguration
            {
                TagForUnderAgeOfConsent = TagForUnderAgeOfConsent.True,
                MaxAdContentRating = MaxAdContentRating.PG
            };
            MobileAds.SetRequestConfiguration(requestConfiguration);



            bannerAd.CreateBannerView();
            bannerAd.ListenToAdEvents();
            bannerAd.LoadAd();
            rewardedAd.LoadRewardedAd();
            var banner = GameObject.Find("BANNER(Clone)");
            DontDestroyOnLoad(banner);


        }


        

    }
}