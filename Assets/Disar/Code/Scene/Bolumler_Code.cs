using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Bolumler_Code : MonoBehaviour {

    public GameObject Content_Mezarlik, Content_Col, Content_Kar, Content_Orman;
    public GameObject Col, Kar, Orman;
    public GameObject Bolüm_btn;
    public GameObject Add_Heal_Btn, Heal_Panel;
    public Image Col_Kilit, Kar_Kilit, Orman_Kilit;
    public int Character_Heal;
    public Text Heall_Text;
    int Level;
    public void Open_Scane(int Değer)
    {
        switch (Değer)
        {
            case 0:
                Application.LoadLevel("Shop");
                break;
            case 1:
                Application.LoadLevel("Menu");
                break;
        }
    }
    void Start()
    {
        Heal_Panel.transform.localScale = new Vector3(0, 0, 0);
        PlayerPrefs.DeleteKey("Total_Yıldız");
        for (int i = 1; i < 10; i++)
        {
            if (PlayerPrefs.GetString(i.ToString()) =="2" || PlayerPrefs.GetString(i.ToString()) == "3")
            {
                PlayerPrefs.SetFloat("Total_Yıldız", PlayerPrefs.GetFloat("Total_Yıldız") + 1);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "4" || PlayerPrefs.GetString(i.ToString()) == "5")
            {
                PlayerPrefs.SetFloat("Total_Yıldız", PlayerPrefs.GetFloat("Total_Yıldız") + 2);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "6")
            {
                PlayerPrefs.SetFloat("Total_Yıldız", PlayerPrefs.GetFloat("Total_Yıldız") + 3);
            }
        }
        Debug.Log(PlayerPrefs.GetFloat("Total_Yıldız") / 15 +","+ PlayerPrefs.GetFloat("Total_Yıldız"));
        Col_Kilit.fillAmount = PlayerPrefs.GetFloat("Total_Yıldız") / 15;
        Kar_Kilit.fillAmount = PlayerPrefs.GetFloat("Total_Yıldız") / 30;
        Orman_Kilit.fillAmount = PlayerPrefs.GetFloat("Total_Yıldız") / 45;
        Time.timeScale = 1;
        Character_Heal = PlayerPrefs.GetInt("Heal");
        Level = PlayerPrefs.GetInt("Level");
        if (PlayerPrefs.GetFloat("Total_Yıldız") >= 15)
        {
            //Col.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Total_Yıldız") >= 30)
        {
            //Kar.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Total_Yıldız") >= 45)
        {
            //Orman.SetActive(false);
        }
        for (int i = 0; i < Content_Mezarlik.transform.childCount; i++)//Content Temzileme
        {
            Destroy(Content_Mezarlik.transform.GetChild(i).gameObject);
        }
        for (int i = 1; i <= 10; i++)
        {
            GameObject newitem = Instantiate(Bolüm_btn, Content_Mezarlik.transform);
            if (Level < i)
            {
                newitem.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (PlayerPrefs.GetString(i.ToString()) == "0")
            {
                newitem.transform.GetChild(5).gameObject.SetActive(true);//Yıldız Gölge
                newitem.transform.GetChild(6).gameObject.SetActive(true);//Yıldız Gölge
                newitem.transform.GetChild(7).gameObject.SetActive(true);//Yıldız Gölge
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "2" || PlayerPrefs.GetString(i.ToString()) == "3")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);//Yıldız 
                newitem.transform.GetChild(6).gameObject.SetActive(true);//Yıldız Gölge
                newitem.transform.GetChild(7).gameObject.SetActive(true);//Yıldız Gölge
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "4" || PlayerPrefs.GetString(i.ToString()) == "5")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);//Yıldız 
                newitem.transform.GetChild(3).gameObject.SetActive(true);//Yıldız 
                newitem.transform.GetChild(7).gameObject.SetActive(true);//Yıldız Gölge
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "6")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
                newitem.transform.GetChild(3).gameObject.SetActive(true);
                newitem.transform.GetChild(4).gameObject.SetActive(true);
            }
            newitem.transform.GetChild(0).GetComponent<Text>().text= i.ToString();
            newitem.name = "Button" + i;
            newitem.GetComponent<Button>().onClick.AddListener(() => Button_Click(newitem.gameObject));
        }
        for (int i = 11; i <= 20; i++)
        {
            /*GameObject newitem = Instantiate(Bolüm_btn, Content_Col.transform);
            if (Level < i)
            {
                newitem.transform.GetChild(1).gameObject.SetActive(true);

            }
            if (PlayerPrefs.GetString(i.ToString()) == "2" || PlayerPrefs.GetString(i.ToString()) == "3")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "4" || PlayerPrefs.GetString(i.ToString()) == "5")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
                newitem.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "6")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
                newitem.transform.GetChild(3).gameObject.SetActive(true);
                newitem.transform.GetChild(4).gameObject.SetActive(true);
            }
            newitem.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            newitem.name = "Button" + i;
            newitem.GetComponent<Button>().onClick.AddListener(() => Button_Click(newitem.gameObject));
            */
        }
        for (int i = 21; i <= 30; i++)
        {
           /* GameObject newitem = Instantiate(Bolüm_btn, Content_Kar.transform);
            if (Level < i)
            {
                newitem.transform.GetChild(1).gameObject.SetActive(true);

            }
            if (PlayerPrefs.GetString(i.ToString()) == "2" || PlayerPrefs.GetString(i.ToString()) == "3")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "4" || PlayerPrefs.GetString(i.ToString()) == "5")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
                newitem.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "6")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
                newitem.transform.GetChild(3).gameObject.SetActive(true);
                newitem.transform.GetChild(4).gameObject.SetActive(true);
            }
            newitem.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            newitem.name = "Button" + i;
            newitem.GetComponent<Button>().onClick.AddListener(() => Button_Click(newitem.gameObject));
            */
        }
        for (int i = 31; i <= 40; i++)
        {
            /*GameObject newitem = Instantiate(Bolüm_btn, Content_Orman.transform);
            if (Level < i)
            {
                newitem.transform.GetChild(1).gameObject.SetActive(true);

            }
            if (PlayerPrefs.GetString(i.ToString()) == "2" || PlayerPrefs.GetString(i.ToString()) == "3")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "4" || PlayerPrefs.GetString(i.ToString()) == "5")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
                newitem.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "6")
            {
                newitem.transform.GetChild(2).gameObject.SetActive(true);
                newitem.transform.GetChild(3).gameObject.SetActive(true);
                newitem.transform.GetChild(4).gameObject.SetActive(true);
            }
            newitem.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            newitem.name = "Button" + i;
            newitem.GetComponent<Button>().onClick.AddListener(() => Button_Click(newitem.gameObject));
            */
        }
    }
    void Button_Click(GameObject Button)
    {
        if (Character_Heal <= 0)
        {
            Heal_Panel.SetActive(true);
            iTween.ScaleTo(Heal_Panel, iTween.Hash("scale", new Vector3(1, 1, 1), "time", .5));
        }
        else
        {
            if (PlayerPrefs.GetInt("Level") >= int.Parse(Button.transform.GetChild(0).GetComponent<Text>().text))
            {
                Application.LoadLevel(Button.transform.GetChild(0).GetComponent<Text>().text);
            }
        }
    }
    void Update()
    {
        Character_Heal = PlayerPrefs.GetInt("Heal");
        Heall();
    }
    void Heall()
    {
        if (Character_Heal < 5)
        {
            Add_Heal_Btn.SetActive(true);
        }
        else
        {
            Add_Heal_Btn.SetActive(false);
        }
        Heall_Text.text = Character_Heal.ToString();
        if (Character_Heal > 5)
        {
            Character_Heal = 5;
            PlayerPrefs.SetInt("Heal", Character_Heal);
        }
    }
}
