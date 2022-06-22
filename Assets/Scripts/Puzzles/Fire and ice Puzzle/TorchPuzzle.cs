using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPuzzle : MonoBehaviour {

    public static bool torch1;
    public static bool torch2;
    public static bool torch3;
    public static bool torch4;
    public static bool torch5;
    public static bool torch6;
    public static bool torch7;
    public static bool torch8;
    public static bool torch9;
    public GameObject greenKeySP;
    public GameObject greenKeyPrefab;
    private GameObject greenKey;
    private GameObject puzzleText;
    private float imageNewObjectTime = 3.0f;


    public AudioClip correct;


    private void Start()
    {
        puzzleText = GameObject.Find("PuzzleCompletedText");
    }

    private void LateUpdate()
    {
        if(GameManager.puzzle6==false)
        {
            if (torch1 && !torch2 && torch3 && !torch4 && torch5 && !torch6 && torch7 && !torch8 && torch9)
            {
                puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 1);
                Invoke("PuzzleCompletedOut", imageNewObjectTime);
                greenKey =Instantiate(greenKeyPrefab, greenKeySP.transform.position, Quaternion.identity);
                greenKey.gameObject.name = "GreenKey";
                GameManager.puzzle6 = true;
                SoundManager.instance.PlaySingle(correct);
            }
        }
    }

    void PuzzleCompletedOut()
    {
        puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 2);
    }
}
