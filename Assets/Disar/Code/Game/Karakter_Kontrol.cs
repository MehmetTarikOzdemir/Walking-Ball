using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter_Kontrol : MonoBehaviour {

    public Rigidbody2D Karakter;
    public float Hiz;
    public float Ziplama;
    public bool jumper;
    public bool Monster;
    int Surekli;
    //Audio Objeler
    public AudioClip Jump,Music;
    public AudioSource Audio;
    private void Start()
    {
        Audio.volume = PlayerPrefs.GetFloat("Audio_Value");
        Audio.clip = Music;
        Audio.time = PlayerPrefs.GetFloat("Audio_Time");
        Audio.loop = true;
        Audio.Play();
    }
    void Update()
    {
        Karakter.AddForce(Vector3.right * Surekli * Time.deltaTime * Hiz / 2);
        //ilkhız = ilkhız + (ivme * time.deltatime / 2);
        if (Audio.time != 0)
        {
            PlayerPrefs.SetFloat("Audio_Time", Audio.time);
        }
        
    }
    public void Controllear(int sağsol)
    {
        Surekli = sağsol;
    }
    public void Zıplama()
    {
        if (jumper==true)
        {
            Karakter.AddForce(Vector3.up * Ziplama);
            Audio.time = 0;
            Audio.clip = Jump;
            Audio.Play();
            StartCoroutine(Audio_Kontrol());
        }
        if (Monster == true)
        {
            Application.LoadLevel(0);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "GR")
        {
            jumper = true;
        }
        if (coll.gameObject.tag == "Monster")
        {
            Monster = true;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "GR")
        {
            jumper = false;
        }
        if (coll.gameObject.tag == "Monster")
        {
            Monster = false;
        }
    }
   IEnumerator Audio_Kontrol()
    {
        yield return new WaitForSeconds(1);
        Start();
    }
}
