using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletTypeChange : MonoBehaviour
{

    [Space]
    [Header("Sprites:")]
    public Sprite normal;
    public Sprite slime;
    public Sprite electric;
    public Sprite ice;
    public Sprite fire;

    private GameObject bulletTypeImg;
    // Use this for initialization
    void Start()
    {
        bulletTypeImg = GameObject.Find("BulletType");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("RightBumper"))
        {
            BulletTypeChanging();
        }

    }

    public void BulletTypeChanging()
    {
        if (GameManager.slimeUnlocked == true)
        {
            GameManager.bulletType = GameManager.bulletType + 1;
        }
          
        if (GameManager.slimeUnlocked == true && GameManager.electricUnlocked == false)
        {
            
            switch (GameManager.bulletType)
            {
                
                case 1:
                    bulletTypeImg.GetComponent<Image>().sprite = normal;
                    GameManager.bulletType = 1;
                    break;
                case 2:
                    bulletTypeImg.GetComponent<Image>().sprite = slime;
                    GameManager.bulletType = 2;
                    break;
                case 3:
                    bulletTypeImg.GetComponent<Image>().sprite = normal;
                    GameManager.bulletType = 1;
                    break;


            }

        }
        if (GameManager.electricUnlocked == true && GameManager.iceUnlocked==false)
        {
            switch (GameManager.bulletType)
            {
                case 1:
                    bulletTypeImg.GetComponent<Image>().sprite = normal;
                    GameManager.bulletType = 1;
                    break;
                case 2:
                    bulletTypeImg.GetComponent<Image>().sprite = slime;
                    GameManager.bulletType = 2;
                    break;
                case 3:
                    bulletTypeImg.GetComponent<Image>().sprite = electric;
                    GameManager.bulletType = 3;
                    break;
                case 4:
                    bulletTypeImg.GetComponent<Image>().sprite = normal;
                    GameManager.bulletType = 1;
                    break;
            }
        }
        if (GameManager.iceUnlocked == true && GameManager.fireUnlocked == false)
        {
            switch (GameManager.bulletType)
            {
                case 1:
                    bulletTypeImg.GetComponent<Image>().sprite = normal;
                    GameManager.bulletType = 1;
                    break;
                case 2:
                    bulletTypeImg.GetComponent<Image>().sprite = slime;
                    GameManager.bulletType = 2;
                    break;
                case 3:
                    bulletTypeImg.GetComponent<Image>().sprite = electric;
                    GameManager.bulletType = 3;
                    break;
                case 4:
                    bulletTypeImg.GetComponent<Image>().sprite = ice;
                    GameManager.bulletType = 4;
                    break;
                case 5:
                    bulletTypeImg.GetComponent<Image>().sprite = normal;
                    GameManager.bulletType = 1;
                    break;

            }
        }
        if (GameManager.fireUnlocked == true)
        {
            switch (GameManager.bulletType)
            {
                case 1:
                    bulletTypeImg.GetComponent<Image>().sprite = fire;
                    GameManager.bulletType = 1;
                    break;
                case 2:
                    bulletTypeImg.GetComponent<Image>().sprite = slime;
                    GameManager.bulletType = 2;
                    break;
                case 3:
                    bulletTypeImg.GetComponent<Image>().sprite = electric;
                    GameManager.bulletType = 3;
                    break;
                case 4:
                    bulletTypeImg.GetComponent<Image>().sprite = ice;
                    GameManager.bulletType = 4;
                    break;
                case 5:
                    bulletTypeImg.GetComponent<Image>().sprite = fire;
                    GameManager.bulletType = 1;
                    break;

            }
        }
    }
}
