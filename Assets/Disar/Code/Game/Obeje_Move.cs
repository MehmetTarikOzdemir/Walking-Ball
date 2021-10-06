using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obeje_Move : MonoBehaviour {

    public GameObject Obje;
    private void Start()
    {
        iTween.MoveTo(Obje, iTween.Hash("position", new Vector3(-4.5f, Obje.transform.position.y, Obje.transform.position.z), "time", 3, "easetype", iTween.EaseType.easeInSine, "LoopType", iTween.LoopType.pingPong));

    }
}
