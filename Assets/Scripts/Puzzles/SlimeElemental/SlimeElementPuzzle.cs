using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeElementPuzzle : MonoBehaviour
{

    private GameObject wall;
    private GameObject button1, button2, button3, button4;
    public static bool fireSwitch, slimeSwitch, electricitySwitch, iceSwitch;
    private GameObject puzzleText;
    private float imageNewObjectTime = 3.0f;

    private void Start()
    {

        puzzleText = GameObject.Find("PuzzleCompletedText");
        fireSwitch = false;
        slimeSwitch = false;
        electricitySwitch = false;
        iceSwitch = false;
        button1 = GameObject.Find("Button_1");
        button2 = GameObject.Find("Button_2");
        button3 = GameObject.Find("Button_3");
        button4 = GameObject.Find("Button_4");
        wall = GameObject.Find("WallRightRoom");
        if (GameManager.puzzle2 == true)
        {
            wall.SetActive(false);
            button1.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            button2.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            button3.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            button4.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            fireSwitch = false;
            slimeSwitch = false;
            electricitySwitch = false;
            iceSwitch = false;
        }
    }
    void LateUpdate()
    {
        if (GameManager.puzzle2 == false)
        {
            if (fireSwitch && slimeSwitch && electricitySwitch && iceSwitch)
            {
                puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 1);
                Invoke("PuzzleCompletedOut", imageNewObjectTime);
                button1.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                button2.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                button3.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                button4.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                wall.SetActive(false);
                GameManager.puzzle2 = true;
            }
        }


    }

    void PuzzleCompletedOut()
    {
        puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 2);
    }

}
