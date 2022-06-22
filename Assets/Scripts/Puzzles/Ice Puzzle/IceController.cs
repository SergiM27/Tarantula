using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour {

    public AudioClip puzzleCompleted;

    public static bool iceTorch1;
    public static bool iceTorch2;
    public static bool iceTorch3;
    public static bool iceTorch4;
    public static bool iceTorch5;
    public static bool iceTorch6;
    public static bool iceTorch7;
    public static bool iceTorch8;
    public static bool iceTorch9;
    public static bool iceTorch10;
    public static bool iceTorch11;
    public static bool iceTorch12;
    public static bool iceTorch13;
    public static bool iceTorch14;
    public static bool iceTorch15;

    public static bool puzzleActive;

    private GameObject chest;
    private GameObject puzzleText;

    private float imageNewObjectTime = 3.0f;

    private void Start()
    {
        chest = GameObject.Find("Chest2ndFloorFire");
        puzzleText = GameObject.Find("PuzzleCompletedText");
        chest.gameObject.SetActive(false);
    }


    void LateUpdate () {
        if (GameManager.puzzle5 == false)
        {
            if (puzzleActive)
            {
                if (iceTorch1 && iceTorch2 && iceTorch3 && iceTorch4 && iceTorch5 && iceTorch6 && iceTorch7 && iceTorch8
                && iceTorch9 && iceTorch10 && iceTorch11 && iceTorch12 && iceTorch13 && iceTorch14 && iceTorch15)
                {
                    SoundManager.instance.PlaySingle2(puzzleCompleted);
                    puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 1);
                    Invoke("PuzzleCompletedOut", imageNewObjectTime);
                    chest.gameObject.SetActive(true);
                    GameManager.puzzle5 = true;
                }
            }
            else
            {
                iceTorch1 = false; iceTorch2 = false; iceTorch3 = false; iceTorch4 = false; iceTorch5 = false;
                iceTorch6 = false; iceTorch7 = false; iceTorch8 = false; iceTorch9 = false; iceTorch10 = false;
                iceTorch11 = false; iceTorch12 = false; iceTorch13 = false; iceTorch14 = false; iceTorch15 = false;
            }
            
        }

	}


    void PuzzleCompletedOut()
    {
        puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 2);
    }
}
