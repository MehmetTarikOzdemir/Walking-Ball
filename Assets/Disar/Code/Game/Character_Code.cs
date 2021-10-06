using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character_Code : MonoBehaviour {
    
    public SpriteRenderer Character;
    public List<Sprite> Karakterler;
    public GameObject Pause_Panel;
    //Audio Durdurma
    public AudioSource Audio;
	void Start () 
    {
        Pause_Panel.transform.localScale = new Vector3(0, 0, 0);
        Character.sprite = Karakterler[PlayerPrefs.GetInt("Select_Record")];
	}
    public void Panleler(int Değer)
    {
        switch (Değer)
        {
            case 1:
                if (Pause_Panel.transform.localScale == new Vector3(0, 0, 0))
                {
                    Audio.Stop();
                    StartCoroutine(Bekleme("1"));
                }
                break;
            case 2:
                Audio.Play();
                Audio.time = PlayerPrefs.GetFloat("Audio_Time");
                StartCoroutine(Bekleme("2"));
                break;
            case 3:
                Application.LoadLevel("Menu");
                Time.timeScale = 1;
                break;
            case 4:
                Application.LoadLevel(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
                break;
            case 5:
                Application.LoadLevel("Episode");
                Time.timeScale = 1;
                break;
        }
    }
    private IEnumerator Bekleme(string ran)
    {
        if (ran=="1")
        {
            Pause_Panel.SetActive(true);
            iTween.ScaleTo(Pause_Panel, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1));

        }
        else if (ran == "2")
        {
            iTween.ScaleTo(Pause_Panel, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1));
            Time.timeScale = 1;
        }
        yield return new WaitForSeconds(1);
        if (ran=="1")
        {
            Time.timeScale = 0;
        }
        else if(ran == "2")
        {
            Time.timeScale = 1;
        }

    }
}
