using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Falow : MonoBehaviour {

    public Transform Character;

	void Start () 
    {
        Character = GameObject.FindGameObjectWithTag("Karakter").transform;
	}
	
	void Update () 
    {
        if (transform.position.x >= -0.055)
        {
            transform.position = new Vector3(Character.position.x, 0, -60);
        }
        
	}
}
