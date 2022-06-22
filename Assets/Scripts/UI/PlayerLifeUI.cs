using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeUI : PlayerLife {

    
    public Sprite[] heartSprite;
    public PlayerLife pl;
    public int life;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;
    public Image heart6;

    private Color normalColor = new Color32(183, 183, 183, 255);


    void Update()
    {
        life = GameManager.playerHealth;

        switch (life)
        {
            case 6:
                heart1.sprite = heartSprite[0];
                heart2.sprite = heartSprite[0];
                heart3.sprite = heartSprite[0];
                heart4.sprite = heartSprite[0];
                heart5.sprite = heartSprite[0];
                heart6.sprite = heartSprite[0];
                break;
            case 5:
                heart1.sprite = heartSprite[0];
                heart2.sprite = heartSprite[0];
                heart3.sprite = heartSprite[0];
                heart4.sprite = heartSprite[0];
                heart5.sprite = heartSprite[0];
                heart6.sprite = heartSprite[1];
                break;
            case 4:
                heart1.color = normalColor;
                heart2.color = normalColor;
                heart1.sprite = heartSprite[0];
                heart2.sprite = heartSprite[0];
                heart3.sprite = heartSprite[0];
                heart4.sprite = heartSprite[0];
                heart5.sprite = heartSprite[1];
                heart6.sprite = heartSprite[1];
                break;
            case 3:
                heart1.color = normalColor;
                heart2.color = normalColor;
                heart1.sprite = heartSprite[0];
                heart2.sprite = heartSprite[0];
                heart3.sprite = heartSprite[0];
                heart4.sprite = heartSprite[1];
                heart5.sprite = heartSprite[1];
                heart6.sprite = heartSprite[1];
                break;
            case 2:
                heart1.color = Color.red;
                heart2.color = Color.red;
                heart1.sprite = heartSprite[0];
                heart2.sprite = heartSprite[0];
                heart3.sprite = heartSprite[1];
                heart4.sprite = heartSprite[1];
                heart5.sprite = heartSprite[1];
                heart6.sprite = heartSprite[1];
                break;
            case 1:
                heart1.color = Color.red;
                heart1.sprite = heartSprite[0];
                heart2.sprite = heartSprite[1];
                heart3.sprite = heartSprite[1];
                heart4.sprite = heartSprite[1];
                heart5.sprite = heartSprite[1];
                heart6.sprite = heartSprite[1];
                break;
            case 0:
                heart1.sprite = heartSprite[1];
                heart2.sprite = heartSprite[1];
                heart3.sprite = heartSprite[1];
                heart4.sprite = heartSprite[1];
                heart5.sprite = heartSprite[1];
                heart6.sprite = heartSprite[1];
                break;

        }
    }
}
