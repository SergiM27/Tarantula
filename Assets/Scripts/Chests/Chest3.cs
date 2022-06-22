using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest3 : MonoBehaviour {

    public AudioClip chestOpen;
    public GameObject canvas;
    private bool chestOpened;
    private GameObject bulletTypeImg;
    public Sprite ice;
    private GameObject imageNewObject;
    public Sprite iceBullet;
    private float imageNewObjectTime = 3.0f;


    private void Start()
    {
        imageNewObject = GameObject.Find("SlotNewObject");
    }

    private void Awake()
    {
        bulletTypeImg = GameObject.Find("BulletType");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (chestOpened == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                canvas.gameObject.SetActive(true);
                if (Input.GetAxis("X Button") > 0)
                {
                    imageNewObject.GetComponent<Image>().sprite = iceBullet;
                    imageNewObject.GetComponent<Animator>().SetInteger("NewObject", 1);
                    imageNewObject.GetComponentInChildren<TextMeshProUGUI>().text = "Ice Bullet Acquired";
                    Invoke("NewObjectOut", imageNewObjectTime);
                    SoundManager.instance.PlaySingle(chestOpen);
                    this.gameObject.GetComponent<Animator>().SetInteger("Chest", 1);
                    chestOpened = true;
                    GameManager.iceUnlocked = true;
                    bulletTypeImg.gameObject.GetComponent<Image>().sprite = ice;
                    GameManager.bulletType = 4;
                    canvas.gameObject.SetActive(false);
                }
            }
        }

    }


    private void NewObjectOut()
    {
        imageNewObject.GetComponent<Animator>().SetInteger("NewObject", 2);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(false);
    }
}