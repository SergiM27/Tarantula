using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTorch15 : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("lit", true);

    }

    void Update()
    {
        if (IceController.iceTorch15) anim.SetBool("lit", false);
        if (IceController.iceTorch15 == false) anim.SetBool("lit", true);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Ice")
        {
            IceController.iceTorch15 = true;
            anim.SetBool("lit", false);
            Destroy(other.gameObject);
        }
    }
}



