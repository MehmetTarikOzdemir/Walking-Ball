using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie_Code : MonoBehaviour {

    public float Zaman;
    float Deger;
	void Start () 
    {
        Deger = Zaman;
	}
    void Update()
    {
        Zaman -= Time.deltaTime;
        if (Zaman <= 0)
        {
            transform.Rotate(0, -180, 0);
            Zaman = Deger;
        }
        transform.Translate(Vector3.right * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
