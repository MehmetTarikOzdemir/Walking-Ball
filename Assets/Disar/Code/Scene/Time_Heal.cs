using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Heal : MonoBehaviour {

    public Text time2;
    int Geçen_Zaman, minutes, seconds,Toplam_Geçen_Zaman;
    string formatedSeconds;
    float totalTime = 900; //Heal Minutes

    void Start()
    {
        if (PlayerPrefs.GetInt("Heal") < 5)
        {
            if (PlayerPrefs.GetInt("Heal") > 5)
            {
                PlayerPrefs.SetInt("Heal", 5);
            }
            string[] real_time = PlayerPrefs.GetString("Real_Time").Split(':');

            totalTime = (Convert.ToInt32(real_time[0]) * 60) + (Convert.ToInt32(real_time[1]));


            PlayerPrefs.SetString("Start_Time", DateTime.Now.ToString("HH:mm:ss"));
            TimeSpan girisCikisFarki = DateTime.Parse(PlayerPrefs.GetString("End_Time")).Subtract(DateTime.Parse(DateTime.Now.ToString("HH:mm:ss")));
            string[] girisCikisFarkitime = girisCikisFarki.ToString().Split(':', '-');
            Toplam_Geçen_Zaman = Toplam_Geçen_Zaman + (60 * Convert.ToInt32(girisCikisFarkitime[1]) * 60) + (60 * Convert.ToInt32(girisCikisFarkitime[2])) + Convert.ToInt32(girisCikisFarkitime[3]);
            if (Toplam_Geçen_Zaman >= 4500)
            {
                PlayerPrefs.SetInt("Heal", PlayerPrefs.GetInt("Heal") + 5);
            }
            else if (Toplam_Geçen_Zaman >= 3600)
            {
                PlayerPrefs.SetInt("Heal", PlayerPrefs.GetInt("Heal") + 4);
            }
            else if (Toplam_Geçen_Zaman >= 2700)
            {
                PlayerPrefs.SetInt("Heal", PlayerPrefs.GetInt("Heal") + 3);
            }
            else if (Toplam_Geçen_Zaman >= 1800)
            {
                PlayerPrefs.SetInt("Heal", PlayerPrefs.GetInt("Heal") + 2);
            }
            else if (Toplam_Geçen_Zaman >= 900)
            {
                PlayerPrefs.SetInt("Heal", PlayerPrefs.GetInt("Heal") + 1);
            }
            else
            {
                totalTime = totalTime - Toplam_Geçen_Zaman;
            }
            //for (int i = 0; i < girisCikisFarkitime.Length; i++)
            //{
            //    Debug.Log(girisCikisFarkitime[i]);
            //}
        }
    }
    private void Update()
    {
        PlayerPrefs.SetString("End_Time", DateTime.Now.ToString("HH:mm:ss"));
        if (PlayerPrefs.GetInt("Heal") < 5)
        {
            PlayerPrefs.SetString("Real_Time", minutes.ToString("00") + ":" + seconds.ToString("00"));
            totalTime -= Time.deltaTime;
            minutes = Mathf.FloorToInt(totalTime / 60f);
            seconds = Mathf.RoundToInt(totalTime % 60f);
            formatedSeconds = seconds.ToString();
            if (seconds == 20)
            {
                seconds = 0;
                minutes += 1;
            }
            if (minutes <= 00 && seconds <= 00)
            {
                if (PlayerPrefs.GetInt("Heal") < 5)
                {
                    totalTime = 900;
                    PlayerPrefs.SetInt("Heal", PlayerPrefs.GetInt("Heal") + 1);
                }

            }
            time2.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        else
        {
            time2.text = "Dolu";
        }
    }
}
