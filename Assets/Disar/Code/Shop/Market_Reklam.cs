using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Market_Reklam : MonoBehaviour {

    BannerView reklamObjesi;
    void Start ()
    {
        MobileAds.Initialize("ca-app-pub-1178918576406149~7587335507");

        reklamObjesi = new BannerView("ca-app-pub-1178918576406149/3282447038", AdSize.SmartBanner, AdPosition.Top);
        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamIstegi);
    }
    public void reklamkapatma()
    {
        reklamObjesi.Hide();
    }
}
