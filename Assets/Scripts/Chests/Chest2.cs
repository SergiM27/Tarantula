using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Chest2 : MonoBehaviour {

    public AudioClip chestOpen;
    public GameObject canvas;
    private bool chestOpened;
    public GameObject bulletTypeImg;
    public Sprite electric;
    private GameObject imageNewObject;
    public Sprite electricBullet;
    private float imageNewObjectTime = 3.0f;


    private void Start()
    {
        imageNewObject = GameObject.Find("SlotNewObject");
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
                    imageNewObject.GetComponent<Image>().sprite = electricBullet;
                    imageNewObject.GetComponent<Animator>().SetInteger("NewObject", 1);
                    imageNewObject.GetComponentInChildren<TextMeshProUGUI>().text = "Electric Bullet Acquired";
                    Invoke("NewObjectOut", imageNewObjectTime);
                    SoundManager.instance.PlaySingle(chestOpen);
                    this.gameObject.GetComponent<Animator>().SetInteger("Chest", 1);
                    chestOpened = true;
                    GameManager.electricUnlocked = true;
                    bulletTypeImg.gameObject.GetComponent<Image>().sprite = electric;
                    GameManager.bulletType = 3;
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
