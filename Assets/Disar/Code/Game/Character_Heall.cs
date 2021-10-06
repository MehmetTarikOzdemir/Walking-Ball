using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Heall : MonoBehaviour {

    public GameObject Content, Heal_image;
    public int Character_Heal;
    public Text Hela_Text;

    private void Update()
    {
        Heall();
    }
    void Heall()
    {
        Hela_Text.text = PlayerPrefs.GetInt("Heal").ToString();
        Character_Heal = PlayerPrefs.GetInt("Heal");
        if (Character_Heal <=0)
        {
            Application.LoadLevel("Bolumler");
        }
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
            for (int i = 1; i <= Character_Heal; i++)
            {
                GameObject newitem = Instantiate(Heal_image, Content.transform);
                newitem.name = "Heal_" + i;
            }
        }
    }
}
