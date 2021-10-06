using UnityEngine;
using UnityEditor;

public class Ball_Select : MonoBehaviour {
    
    public void Geçiş(int Değer)
     {
        switch (Değer)
        {
            case 1:
                Application.LoadLevel("Menu");
                break;
            case 2:
                Application.LoadLevel("Episode");
                break;
        }
     }
}

