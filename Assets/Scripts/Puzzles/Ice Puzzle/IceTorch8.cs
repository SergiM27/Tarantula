using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTorch8 : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("lit", true);

    }

    void Update()
    {
        if (IceController.iceTorch8) anim.SetBool("lit", false);
        if (IceController.iceTorch8 == false) anim.SetBool("lit", true);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Ice")
        {
            IceController.iceTorch8 = true;
            anim.SetBool("lit", false);
            Destroy(other.gameObject);
        }
    }
}



