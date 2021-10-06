using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bildirim : MonoBehaviour {

    GameObject Obje;
    Image Obje_image;
    float Timer;
    //Public
    public Canvas Atılıcak_Yer;
    public float Hiz ;

    private void Start()
    {
        //Calıstırma();
    }
    public void Calıstırma()
    {
        Timer = Atılıcak_Yer.transform.position.x * 2.35f;
        Destroy(Obje);
        Obje = new GameObject("Bildirim");
        Obje_image = Obje.AddComponent<Image>();
        Obje_image.rectTransform.sizeDelta = new Vector2(400, 90);
        Obje_image.rectTransform.position = new Vector3(Atılıcak_Yer.transform.position.x*2.35f, Atılıcak_Yer.transform.position.y*1.5f, 0);
        Obje_image.transform.SetParent(Atılıcak_Yer.transform);
        PlayerPrefs.SetInt("Başlama_Kayit",1);
    }
    //private void Update()
    //{
    //    Timer -= Hiz;
    //    if (PlayerPrefs.GetInt("Başlama_Kayit")==1)
    //    {
    //        Obje_image.rectTransform.position = new Vector3(Timer, Atılıcak_Yer.transform.position.y * 1.5f, 0);
    //        if (Timer < (Atılıcak_Yer.transform.position.x * 2.35f) / 1.4)
    //        {
    //            PlayerPrefs.SetInt("Başlama_Kayit", 0);
    //        }
    //    }
    //    if (Timer <= 800)
    //    {

    //        Destroy(Obje);

    //    }

    //}
}
