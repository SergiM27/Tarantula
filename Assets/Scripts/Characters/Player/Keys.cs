using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Keys : MonoBehaviour
{
    private GameObject redKey;
    private GameObject blueKey;
    private GameObject yellowKey;
    private GameObject greenKey;
    private GameObject imageNewObject;
    private GameObject puzzleCompleted;
    public Sprite redKeySP;
    public Sprite blueKeySP;
    public Sprite yellowKeySP;
    public Sprite greenKeySP;
    private float imageNewObjectTime = 3.0f;
    private float puzzleCompletedTime = 5.0f;


    private void Awake()
    {
        puzzleCompleted = GameObject.Find("PuzzleCompletedText");
        imageNewObject = GameObject.Find("SlotNewObject");
        redKey = GameObject.Find("RedKeyIcon");
        blueKey = GameObject.Find("BlueKeyIcon");
        yellowKey = GameObject.Find("YellowKeyIcon");
        greenKey = GameObject.Find("GreenKeyIcon");
        if (SceneManager.GetSceneByName("Level1") == SceneManager.GetActiveScene())
        {
            if (GameManager.brisingrHealth > 0)
            {
                redKey.SetActive(false);
                blueKey.SetActive(false);
                yellowKey.SetActive(false);
                greenKey.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Drop"))
        {
            if (other.gameObject.name == "RedKey")
            {
                imageNewObject.GetComponent<Image>().sprite = redKeySP;
                imageNewObject.GetComponent<Animator>().SetInteger("NewObject", 1);
                imageNewObject.GetComponentInChildren<TextMeshProUGUI>().text = "Red Key Acquired";
                Invoke("NewObjectOut", imageNewObjectTime);
                Invoke("PuzzleCompletedTrue", puzzleCompletedTime);
                redKey.SetActive(true);
                GameManager.redKey = true;
                Destroy(other.gameObject);
                puzzleCompleted.gameObject.SetActive(false);

            }
            else if (other.gameObject.name == "BlueKey")
            {
                imageNewObject.GetComponent<Image>().sprite = blueKeySP;
                imageNewObject.GetComponent<Animator>().SetInteger("NewObject", 1);
                imageNewObject.GetComponentInChildren<TextMeshProUGUI>().text = "Blue Key Acquired";
                Invoke("NewObjectOut", imageNewObjectTime);
                Invoke("PuzzleCompletedTrue", puzzleCompletedTime);
                blueKey.SetActive(true);
                GameManager.blueKey = true;
                Destroy(other.gameObject);
                puzzleCompleted.gameObject.SetActive(false);

            }
            else if (other.gameObject.name == "YellowKey")
            {
                imageNewObject.GetComponent<Image>().sprite = yellowKeySP;
                imageNewObject.GetComponent<Animator>().SetInteger("NewObject", 1);
                imageNewObject.GetComponentInChildren<TextMeshProUGUI>().text = "Yellow Key Acquired";
                Invoke("NewObjectOut", imageNewObjectTime);
                Invoke("PuzzleCompletedTrue", puzzleCompletedTime);
                yellowKey.SetActive(true);
                GameManager.yellowKey = true;
                Destroy(other.gameObject);
                puzzleCompleted.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 255, 255, 0);
                puzzleCompleted.gameObject.SetActive(false);

            }
            else if (other.gameObject.name == "GreenKey")
            {
                imageNewObject.GetComponent<Image>().sprite = greenKeySP;
                imageNewObject.GetComponent<Animator>().SetInteger("NewObject", 1);
                imageNewObject.GetComponentInChildren<TextMeshProUGUI>().text = "Green Key Acquired";
                Invoke("NewObjectOut", imageNewObjectTime);
                Invoke("PuzzleCompletedTrue", puzzleCompletedTime);
                greenKey.SetActive(true);
                GameManager.greenKey = true;
                Destroy(other.gameObject);
                puzzleCompleted.gameObject.SetActive(false);

            }
        }

    }

    private void NewObjectOut()
    {
        imageNewObject.GetComponent<Animator>().SetInteger("NewObject", 2);
    }

    private void PuzzleCompletedTrue()
    {
        puzzleCompleted.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 255, 255, 0);
        puzzleCompleted.gameObject.SetActive(true);
    }
}

