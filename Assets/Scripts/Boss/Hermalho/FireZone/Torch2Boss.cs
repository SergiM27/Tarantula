using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch2Boss : MonoBehaviour {


    int i;
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch2 = true;
            anim.SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch2 = false;
            anim.SetBool("lit", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Fire")
        {
            FireZoneManager.fireZoneTorch2 = true;
            anim.SetBool("lit", true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Bullet_Ice")
        {
            FireZoneManager.fireZoneTorch2 = false;
            anim.SetBool("lit", false);
            Destroy(other.gameObject);
        }
    }

    public void RandomAgain()
    {
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch1 = true;
            anim.SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch1 = false;
            anim.SetBool("lit", false);
        }
    }
}
