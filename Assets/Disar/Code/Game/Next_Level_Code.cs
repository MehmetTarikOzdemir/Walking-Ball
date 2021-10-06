using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next_Level_Code : MonoBehaviour {

    public int scene;
    float Yildiz;
    public Scrollbar Yildiz_Bar;
    string Yildiz_Name;
    //Zıplatma
    public float Ziplama;
    public Rigidbody2D Karakter;
    //Kontrol
    int Kontrol=0;
    private void Start()
    {
        //Debug.Log(PlayerPrefs.GetString(SceneManager.GetActiveScene().name));
    }
    void OnTriggerEnter2D(Collider2D Nesne)
    {
        if (Nesne.tag == "1")
        {

            string[] Oynanan_Bölümler = PlayerPrefs.GetString("Oynanan_Bölümler").Split(',');
            for (int i = 0; i < Oynanan_Bölümler.Length; i++)
            {
                if (Oynanan_Bölümler[i] == SceneManager.GetActiveScene().name)
                {
                    Kontrol = 1;
                    break;
                }
            }
            if (Kontrol == 0)
            {
                scene = int.Parse(SceneManager.GetActiveScene().name) + 1;
                PlayerPrefs.SetInt("Level", scene);
                PlayerPrefs.SetString("Oynanan_Bölümler", PlayerPrefs.GetString("Oynanan_Bölümler") + SceneManager.GetActiveScene().name + ",");
                Kontrol = 0;
            }
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name, Yildiz.ToString());//Yıldız Kayıt

            if (int.Parse(SceneManager.GetActiveScene().name) != 10)
            {
                Application.LoadLevel((int.Parse(SceneManager.GetActiveScene().name) + 1).ToString());
            }
            else
            {
                Application.LoadLevel("Bolumler");
            }
        }
        if (Nesne.tag == "Zombie")
        {
            Karakter.AddForce(Vector3.up * Ziplama);
            PlayerPrefs.SetInt("Heal", PlayerPrefs.GetInt("Heal") - 1);
        }
        Yildiz_Name += Nesne.gameObject.name + ",";
        if (Nesne.gameObject.tag == "Yıldız")
        {
            Yildiz += +1;
            Destroy(Nesne.gameObject);
            Yildiz_Bar.size = Yildiz / 6f;
        }
        if (Nesne.tag=="Dying")
        {
            StartCoroutine(GameOver());
        }

    }
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(.5f);
        PlayerPrefs.SetInt("Heal", PlayerPrefs.GetInt("Heal") - 1);
        Application.LoadLevel(SceneManager.GetActiveScene().name);
    }
}
