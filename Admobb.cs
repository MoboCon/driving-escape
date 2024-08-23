using UnityEngine;
using GoogleMobileAds.Api;
using System;

//Banner ad
public class Admobb : MonoBehaviour
{
	private BannerView adBanner;

	private string idApp, idBanner;


	void Start()
	{
		idApp = "ca-app-pub-7679776067083130~4844269313";
		idBanner = "ca-app-pub-7679776067083130/2189066250";

		MobileAds.Initialize(idApp);

		RequestBannerAd();
	}



	#region Banner Methods --------------------------------------------------

	public void RequestBannerAd()
	{
		adBanner = new BannerView(idBanner, AdSize.Banner, AdPosition.Bottom);
		AdRequest request = AdRequestBuild();
		adBanner.LoadAd(request);
	}

	public void DestroyBannerAd()
	{
		if (adBanner != null)
			adBanner.Destroy();
	}

	#endregion


	//------------------------------------------------------------------------
	AdRequest AdRequestBuild()
	{
		return new AdRequest.Builder().Build();
	}

	void OnDestroy()
	{
		DestroyBannerAd();
	}

}
