using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTorch2 : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("lit", true);

    }

    void Update()
    {
        if (IceController.iceTorch2) anim.SetBool("lit", false);
        if (IceController.iceTorch2 == false) anim.SetBool("lit", true);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Ice")
        {
            IceController.iceTorch2 = true;
            anim.SetBool("lit", false);
            Destroy(other.gameObject);
        }
    }
}



