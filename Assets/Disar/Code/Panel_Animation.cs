using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Animation : MonoBehaviour {

    public void Animation_Open(GameObject Panel)
    {
        Panel.transform.localScale = new Vector3(0, 0, 0);
        Panel.SetActive(true);
        iTween.ScaleTo(Panel, iTween.Hash("scale", new Vector3(1, 1, 1), "time", .5));
    }
    public void Animation_Close(GameObject Panel)
    {
        iTween.ScaleTo(Panel, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5));
    }
}
