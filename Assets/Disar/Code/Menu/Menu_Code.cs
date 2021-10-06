using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Code : MonoBehaviour {

    public GameObject Ayarlar_Panel;
    public CanvasScaler canvas;
    //Ayarlar Ses
    public Slider Audio_Value;
    private void Start()
    {
        //GizlilikSozlesmesi.value = 1;
        canvas.matchWidthOrHeight = 0.2f;
        
        Audio_Value.value = PlayerPrefs.GetFloat("Audio_Value");

        //Time.timeScale = 1;
        if (PlayerPrefs.GetInt("Kontrol1") == 0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Kontrol1", 1);
        }
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("Kontrol", 0);
        }
        if (PlayerPrefs.GetInt("Kontrol") == 0)
        {
            PlayerPrefs.SetInt("Heal", 5);
            PlayerPrefs.SetInt("Kontrol", 1);
        }
    }
    public void Open(int Değer)
    {
        switch (Değer)
        {
            case 1:
                Application.LoadLevel(1);
                break;
            case 3:
                Application.LoadLevel(2);
                break;
        }
    }
    public void Sifirla_Button()
    {
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("Kontrol1") == 0)
        {
            PlayerPrefs.SetFloat("Audio_Value", 1);
            Audio_Value.value = 1;
            PlayerPrefs.SetInt("Kontrol1", 1);
        }
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("Kontrol", 0);
        }
        if (PlayerPrefs.GetInt("Kontrol") == 0)
        {
            PlayerPrefs.SetInt("Heal", 5);
            PlayerPrefs.SetInt("Kontrol", 1);
        }
        iTween.ScaleTo(Ayarlar_Panel, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5));

    }
    public void Audio_Value_Save(int Değer)
    {
        if (Değer == 1)
        {
            //PlayerPrefs.SetFloat("Audio_Value", Audio_Value.value);
            PlayerPrefs.SetFloat("Audio_Value", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("Audio_Value", Audio_Value.value);
        }
        
    }
}
