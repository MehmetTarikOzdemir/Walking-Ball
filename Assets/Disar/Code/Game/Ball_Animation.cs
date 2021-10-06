using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Animation : MonoBehaviour {

    public GameObject Ball;
	void Start () {
        Ball.transform.localScale = new Vector3(0, 0, 0);
        iTween.ScaleTo(Ball, iTween.Hash("scale", new Vector3(0.25f, 0.25f, 1), "time", .5, "delay", .4));	
	}
}
