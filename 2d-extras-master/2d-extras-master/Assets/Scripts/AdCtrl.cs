using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdCtrl : MonoBehaviour
{

    public static AdCtrl instance = null;

    //public string Admob_Android_Id;
    //public string Admob_Android_Id_Inters;

    public string Admob_IOS_Id;
    public string Admob_IOS_Id_Inters;


    public bool testMode;
    public float duration;

    private BannerView bannerView;
    private InterstitialAd interstitialAd;


    private AdRequest request;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   


    private void RequestBanner()
    {
        if(testMode)
        {
            bannerView = new BannerView(Admob_IOS_Id, AdSize.Banner, AdPosition.Top);

        }
        else
        {
            bannerView = new BannerView(Admob_IOS_Id, AdSize.Banner, AdPosition.Top);

        }

        AdRequest adRequest = new AdRequest.Builder().Build();

        bannerView.LoadAd(adRequest);
        HideBanner();

    }


    private void RequestInter()
    {
        if (testMode)
        {
            interstitialAd = new InterstitialAd(Admob_IOS_Id_Inters);

        }
        else
        {
            interstitialAd = new InterstitialAd(Admob_IOS_Id_Inters);
        }
        request = new AdRequest.Builder().Build() ;
        interstitialAd.LoadAd(request);
        interstitialAd.OnAdClosed += HandleOnAdClosed;

    }

    public void HandleOnAdClosed(object sender, System.EventArgs args)
    {
        interstitialAd.Destroy();
        RequestInter();
    }


    public void ShowInter()
    {
        if(interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }



    public void ShowBanner()
    {
        bannerView.Show();
    }


    public void HideBanner()
    {
        bannerView.Hide();
    }
    public void HideBanner(float duration)
    {
        StartCoroutine("HideTimeBanner",duration);
    }

    IEnumerator HideTimeBanner(float duration)
    {
        yield return new WaitForSeconds(duration);
        bannerView.Hide();
    }

    private void OnEnable()
    {
        RequestBanner();
        RequestInter();
    }

    private void OnDisable()
    {
        bannerView.Destroy();
        interstitialAd.Destroy();
    }



}
