using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDead : MonoBehaviour {

    public GameObject coin, heart, skull, potion, boot, star;

    public AudioClip death;

    private void Start()
    {
        SoundManager.instance.PlaySingle(death);
        int choice = Random.Range(1, 100);
        if (choice >= 1 && choice <= 60)
        {
            GameObject coinDrop = Instantiate(coin, transform.position, Quaternion.identity);
            coinDrop.gameObject.name = "Coin";
        }
        else if (choice > 60 && choice <= 80)
        {
            GameObject heartDrop = Instantiate(heart, transform.position, Quaternion.identity);
            heartDrop.gameObject.name = "Heart";
        }
        else if (choice > 80 && choice <= 85)
        {
            GameObject potionDrop = Instantiate(potion, transform.position, Quaternion.identity);
            potionDrop.gameObject.name = "HealthPot";
        }
        else if (choice > 85 && choice <= 90)
        {
            GameObject bootDrop = Instantiate(boot, transform.position, Quaternion.identity);
            bootDrop.gameObject.name = "Boot";
        }
        else if (choice > 90 && choice <= 95)
        {
            GameObject skullDrop = Instantiate(skull, transform.position, Quaternion.identity);
            skullDrop.gameObject.name = "Skull";
        }
        else if (choice > 95 && choice <= 100)
        {

            GameObject starDrop = Instantiate(star, transform.position, Quaternion.identity);
            starDrop.gameObject.name = "Star";
        }
        Destroy(this.gameObject);
    }
}
