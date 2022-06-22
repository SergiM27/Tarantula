using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : MonoBehaviour {

    public AudioClip puzzleCompleted;

    public static bool firstSwitch = false;
    public static bool secondSwitch = false;
    private float time=4.0f;
    public GameObject key;
    private GameObject puzzleText;
    private float imageNewObjectTime = 3.0f;

    private void Start()
    {
        if (GameManager.puzzle1 == false)
        {
            firstSwitch = false;
            secondSwitch = false;
        }
        puzzleText = GameObject.Find("PuzzleCompletedText");
    }

    void LateUpdate()
    {
        if (GameManager.puzzle1 == false)
        {
            if (firstSwitch && secondSwitch)
            {
                SoundManager.instance.PlaySingle2(puzzleCompleted);
                puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 1);
                GameObject redKey = Instantiate(key, this.gameObject.transform.position, Quaternion.identity);
                redKey.gameObject.name = "RedKey";
                GameManager.puzzle1 = true;
                Invoke("PuzzleCompletedOut", imageNewObjectTime);
                Invoke("DestroyThis", time);
            }
        }
    }

    void PuzzleCompletedOut()
    {
        puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 2);
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
