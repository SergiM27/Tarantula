using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZoneManager : MonoBehaviour {

    public AudioClip correct;
    public static bool fireZoneTorch1;
    public static bool fireZoneTorch2;
    public static bool fireZoneTorch3;
    public static bool fireZoneTorch4;
    public static bool fireZoneTorch5;
    public static bool fireZoneTorch6;
    public static bool fireZoneTorch7;
    public static bool fireZoneTorch8;
    public static bool fireZoneTorch9;

	void LateUpdate () {
        if (GameManager.HermalhofirePuzzle == false)
        {
            if (fireZoneTorch1 && fireZoneTorch2 && fireZoneTorch3 && !fireZoneTorch4 && fireZoneTorch5 && fireZoneTorch6 && fireZoneTorch7 && !fireZoneTorch8 && fireZoneTorch9)
            {
                GameManager.HermalhofirePuzzle = true;
                SoundManager.instance.PlaySingle(correct);
            }
        }
    
    }
}
