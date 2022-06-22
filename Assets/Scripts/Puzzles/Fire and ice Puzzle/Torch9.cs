using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch9 : MonoBehaviour
{

    int i;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        TorchPuzzle.torch9 = false;
        anim.SetBool("lit", false);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Fire")
        {
            TorchPuzzle.torch9 = true;
            anim.SetBool("lit", true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Bullet_Ice")
        {
            TorchPuzzle.torch9 = false;
            anim.SetBool("lit", false);
            Destroy(other.gameObject);
        }
    }
}


