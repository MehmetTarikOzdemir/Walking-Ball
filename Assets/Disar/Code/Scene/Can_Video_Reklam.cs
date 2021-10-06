using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Can_Video_Reklam : MonoBehaviour
{
    public Button Reklam_Btn;
    private void Update()
    {
        if (RewardBasedVideoAd.Instance.IsLoaded() == true)
        {
            Reklam_Btn.interactable=true;
        }
        else
        {
            Reklam_Btn.interactable=false;
        }
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("Heal") < 5)
        {
            MobileAds.Initialize("ca-app-pub-1178918576406149~7587335507");
            YeniReklamAl(null, null);

            RewardBasedVideoAd reklamObjesi = RewardBasedVideoAd.Instance;
            reklamObjesi.OnAdClosed -= YeniReklamAl;
            reklamObjesi.OnAdClosed += YeniReklamAl; // Kullanıcı reklamı kapattıktan sonra çağrılır
            reklamObjesi.OnAdRewarded -= OyuncuyuOdullendir;
            reklamObjesi.OnAdRewarded += OyuncuyuOdullendir; // Kullanıcı reklamı tamamen izledikten sonra çağrılır
        }
    }
    public void Reklam_Start()
    {
        if (RewardBasedVideoAd.Instance.IsLoaded() == true) 
        {
            RewardBasedVideoAd.Instance.Show();
        }
        else
        {
            Debug.Log("Reklam Yükleniyor!!!");
        }
    }
    public void YeniReklamAl(object sender, EventArgs args)
    {
        RewardBasedVideoAd reklamObjesi = RewardBasedVideoAd.Instance;

        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamIstegi, "ca-app-pub-1178918576406149/2790449831");
    }
    private void OyuncuyuOdullendir(object sender, Reward odul)
    {
        PlayerPrefs.SetInt("Heal", PlayerPrefs.GetInt("Heal") + 1);

    }
}