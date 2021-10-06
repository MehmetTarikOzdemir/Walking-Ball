using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Move : MonoBehaviour {
    
    public GameObject Man,Fam;
    public GameObject Btn_1, Btn_2, Btn_3,Game_Name;
	void Start () 
    {
        iTween.MoveTo(Man, iTween.Hash("position", new Vector3(55, Man.transform.position.y, Man.transform.position.z), "time", 3, "easetype", iTween.EaseType.easeOutElastic));
        iTween.MoveTo(Fam, iTween.Hash("position", new Vector3(1900, Fam.transform.position.y, Fam.transform.position.z), "time", 3, "easetype", iTween.EaseType.easeOutElastic));
        //Button Animation
        Btn_1.transform.localScale = new Vector3(0, 0, 0);
        Btn_2.transform.localScale = new Vector3(0, 0, 0);
        Btn_3.transform.localScale = new Vector3(0, 0, 0);
        Game_Name.transform.localScale = new Vector3(0, 0, 0);
        iTween.ScaleTo(Btn_1, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1, "delay", .2, "easetype", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(Btn_2, iTween.Hash("scale", new Vector3(1, 1,1), "time", 1,"delay",.2, "easetype", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(Btn_3, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1, "delay", .2, "easetype", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(Game_Name, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1, "delay", .2, "easetype", iTween.EaseType.easeOutElastic));
	}
}
