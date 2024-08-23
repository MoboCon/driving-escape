using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;

//Interstitial ad
public class AdmobIntestiial : MonoBehaviour

{ 
    private InterstitialAd interstitial;

void Start()
{
    string appId = "ca-app-pub-7679776067083130~4844269313";

    MobileAds.Initialize(appId);
}

public void ShowInterstitial()
{

    RequestInterstitial();


}

private void RequestInterstitial()
{
    string interstitialId = "ca-app-pub-7679776067083130/4176580123";

    if (interstitial != null)
        interstitial.Destroy();
    interstitial = new InterstitialAd(interstitialId);
    interstitial.OnAdLoaded += HandleOnAdLoaded;

    interstitial.LoadAd(CreateNewRequest());
}

public void HandleOnAdLoaded(object sender, EventArgs args)
{
    if (interstitial.IsLoaded())
        interstitial.Show();
}


private AdRequest CreateNewRequest()
{
    return new AdRequest.Builder().Build();
}
}
