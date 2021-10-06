using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour {
    
    public AudioClip Music;
    public AudioSource Audio_Bölümler;

    void Start ()
    {
        Audio_Bölümler.time = PlayerPrefs.GetFloat("Audio_Time");
        Audio_Bölümler.clip = Music;
        Audio_Bölümler.volume = PlayerPrefs.GetFloat("Audio_Value");
        Audio_Bölümler.loop = true;
        Audio_Bölümler.Play();
    }

    void Update()
    {
        //PlayerPrefs.SetFloat("Audio_Time", Audio_Bölümler.time);
        Audio_Bölümler.volume = PlayerPrefs.GetFloat("Audio_Value");
    }
}
