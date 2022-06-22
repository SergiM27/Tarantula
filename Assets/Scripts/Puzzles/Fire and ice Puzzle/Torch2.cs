using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch2 : MonoBehaviour {

    int i;
    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
        TorchPuzzle.torch2 = true;
        anim.SetBool("lit", true);
       
	}
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Fire")
        {
            TorchPuzzle.torch2 = true;
            anim.SetBool("lit", true);
            Destroy(other.gameObject);

        }
        if (other.gameObject.name == "Bullet_Ice")
        {
            TorchPuzzle.torch2 = false;
            anim.SetBool("lit", false);
            Destroy(other.gameObject);

        }
    }
}


