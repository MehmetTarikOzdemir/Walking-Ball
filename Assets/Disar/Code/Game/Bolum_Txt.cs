using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bolum_Txt : MonoBehaviour {

    public Text Bolum_txt;
    float time = 3;

    void Update()
    {
        time -= Time.deltaTime;
        Bolum_txt.text = "";
        if (time >= 0)
        {
            Bolum_txt.text = "LEVEL " + SceneManager.GetActiveScene().name;
        }
    }
}
