using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bölümler : MonoBehaviour
{

    public GameObject Content_Mezarlik, Content_Col, Content_Kar, Content_Orman;
    public GameObject Col, Kar, Orman;
    public GameObject Bolüm_btn, Lock_image;
    public GameObject Content, Heal_image;
    public GameObject Add_Heal_Btn,Heal_Panel;
    public GameObject Yildiz_1, Yildiz_2, Yildiz_3;
    public int Character_Heal;
    public Button Bolüm_Bütton;
    public Text Bolüm_btn_text,Heall_Text;
    int Level;
    string Button_Text;
    public void Open_Scane(int Değer)
    {
        switch (Değer)
        {
            case 0:
                Application.LoadLevel("Market");
                break;
            case 1:
                Application.LoadLevel("Menu");
                break;
        }
    }
    public void Heall_Panel(int Deger)
    {
        switch (Deger)
        {
            case 0:
                Heal_Panel.SetActive(false);
                break;
            case 1:
                Heal_Panel.SetActive(true);
                break;
        }
    }
    void Start()
    {
        Time.timeScale = 1;
        Character_Heal = PlayerPrefs.GetInt("Heal");
        Level = PlayerPrefs.GetInt("Level");

        if (Level >= 8)
        {
            Col.SetActive(false);
        }
        if (Level >= 18)
        {
            Kar.SetActive(false);
        }
        if (Level >= 28)
        {
            Orman.SetActive(false);
        }

        for (int i = 0; i < Content_Mezarlik.transform.childCount; i++)//Content Temzileme
        {
            Destroy(Content_Mezarlik.transform.GetChild(i).gameObject);
        }
        for (int i = 1; i <= 10; i++)
        {
            Yildiz_Colse();
            if (Level < i)
            {
                Lock_image.SetActive(true);
                Bolüm_Bütton.interactable = false;
            }
            if (PlayerPrefs.GetString(i.ToString()) == "2" || PlayerPrefs.GetString(i.ToString()) == "3")
            {
                Yildiz_1.SetActive(true);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "4" || PlayerPrefs.GetString(i.ToString()) == "5")
            {
                Yildiz_1.SetActive(true);
                Yildiz_2.SetActive(true);
            }
            else if (PlayerPrefs.GetString(i.ToString()) == "6")
            {
                Yildiz_1.SetActive(true);
                Yildiz_2.SetActive(true);
                Yildiz_3.SetActive(true);
            }
            Bolüm_btn_text.text = i.ToString();
            GameObject newitem = Instantiate(Bolüm_btn);
            newitem.name = "Button" + i;
            newitem.transform.parent = Content_Mezarlik.transform;
            newitem.GetComponent<Button>().onClick.AddListener(() => Button_Click(newitem.gameObject));
            Lock_image.SetActive(false);
            Bolüm_Bütton.interactable = true;

        }

        for (int i = 11; i <= 20; i++)
        {
            if (Level < i)
            {
                Lock_image.SetActive(true);
                Bolüm_Bütton.interactable = false;
            }
            Bolüm_btn_text.text = i.ToString();
            GameObject newitem = Instantiate(Bolüm_btn);
            newitem.name = "Button" + i;
            newitem.transform.parent = Content_Col.transform;
            newitem.GetComponent<Button>().onClick.AddListener(() => Button_Click(newitem.gameObject));
            Lock_image.SetActive(false);
            Bolüm_Bütton.interactable = true;
        }
        for (int i = 21; i <= 30; i++)
        {
            if (Level < i)
            {
                Lock_image.SetActive(true);
                Bolüm_Bütton.interactable = false;
            }
            Bolüm_btn_text.text = i.ToString();
            GameObject newitem = Instantiate(Bolüm_btn);
            newitem.name = "Button" + i;
            newitem.transform.parent = Content_Kar.transform;
            newitem.GetComponent<Button>().onClick.AddListener(() => Button_Click(newitem.gameObject));
            Lock_image.SetActive(false);
            Bolüm_Bütton.interactable = true;
        }
        for (int i = 31; i <= 40; i++)
        {
            if (Level < i)
            {
                Lock_image.SetActive(true);
                Bolüm_Bütton.interactable = false;
            }
            Bolüm_btn_text.text = i.ToString();
            GameObject newitem = Instantiate(Bolüm_btn);
            newitem.name = "Button" + i;
            newitem.transform.parent = Content_Orman.transform;
            newitem.GetComponent<Button>().onClick.AddListener(() => Button_Click(newitem.gameObject));
            Lock_image.SetActive(false);
            Bolüm_Bütton.interactable = true;
        }
    }
    void Button_Click(GameObject Button)
    {
        Button_Text = Button.transform.GetChild(0).GetComponent<Text>().text;
        if (Character_Heal <= 0)
        {
            Heall_Panel(1);
        }
        else
        {
            Application.LoadLevel(Button_Text);
        }

    }

    private void Update()
    {
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
        }
        else
        {
            for (int i = 0; i < Content.transform.childCount; i++)
            {
                Destroy(Content.transform.GetChild(i).gameObject);
            }
            Heal_image.SetActive(true);

            for (int i = 1; i <= Character_Heal; i++)
            {
                GameObject newitem = Instantiate(Heal_image);
                newitem.name = "Heal_" + i;
                newitem.transform.parent = Content.transform;
            }
            Heal_image.SetActive(false);
        }
    }
    void Yildiz_Colse()
    {
        Yildiz_1.SetActive(false);
        Yildiz_2.SetActive(false);
        Yildiz_3.SetActive(false);
    }
}