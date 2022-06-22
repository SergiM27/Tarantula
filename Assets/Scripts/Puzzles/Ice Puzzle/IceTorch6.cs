using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTorch6 : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("lit", true);

    }

    void Update()
    {
        if (IceController.iceTorch6) anim.SetBool("lit", false);
        if (IceController.iceTorch6 == false) anim.SetBool("lit", true);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Ice")
        {
            IceController.iceTorch6 = true;
            anim.SetBool("lit", false);
            Destroy(other.gameObject);
        }
    }
}



