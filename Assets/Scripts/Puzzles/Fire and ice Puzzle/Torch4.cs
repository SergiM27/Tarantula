using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch4 : MonoBehaviour {

    int i;
    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
        i = Random.Range(0, 2);
        if (i == 1)
        {
            TorchPuzzle.torch4 = true;
            anim.SetBool("lit", true);
        }
        else
        {
            TorchPuzzle.torch4 = false;
            anim.SetBool("lit", false);
        }
       
	}
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Fire")
        {
            TorchPuzzle.torch4 = true;
            anim.SetBool("lit", true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Bullet_Ice")
        {
            TorchPuzzle.torch4 = false;
            anim.SetBool("lit", false);
            Destroy(other.gameObject);
        }
    }
}


