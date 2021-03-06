using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch9Boss : MonoBehaviour {

    int i;
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch9 = true;
            anim.SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch9 = false;
            anim.SetBool("lit", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Fire")
        {
            FireZoneManager.fireZoneTorch9 = true;
            anim.SetBool("lit", true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Bullet_Ice")
        {
            FireZoneManager.fireZoneTorch9 = false;
            anim.SetBool("lit", false);
            Destroy(other.gameObject);
        }
    }
    public void RandomAgain()
    {
       FireZoneManager.fireZoneTorch1 = false;
       anim.SetBool("lit", false);
    }
}
