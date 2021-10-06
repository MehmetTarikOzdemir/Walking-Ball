using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Reklam : MonoBehaviour {


    private InterstitialAd interstitial;
    private void Start()
    {
        MobileAds.Initialize("ca-app-pub-1178918576406149~7587335507");
        if (interstitial != null)
            interstitial.Destroy();

        interstitial = new InterstitialAd("ca-app-pub-1178918576406149/8662766227");
        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        interstitial.LoadAd(reklamIstegi);

        StartCoroutine(ReklamiGoster());
    }
    IEnumerator ReklamiGoster()
    {
        while (!interstitial.IsLoaded())
            yield return null;

        interstitial.Show();
    }
}
