using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElementalButton : MonoBehaviour {

    int buttonColor = 0;
    Animator anim;
    public AudioClip buttonPressed;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (GameManager.puzzle2 == false)
        {
            while (buttonColor == 0)
            {
                buttonColor = Random.Range(0, 4);
                anim.SetInteger("color", buttonColor);
            }
        }
    }
	
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Slime")
        {
            SoundManager.instance.PlaySingle(buttonPressed);
            buttonColor++;
            if (buttonColor == 4)
                buttonColor = 0;

            switch (buttonColor)
            {
                case 0: //FIRE - CORRECT
                    anim.SetInteger("color", 0);
                    SlimeElementPuzzle.fireSwitch = true;
                    break;
                case 1: //SLIME
                    anim.SetInteger("color", 1);
                    SlimeElementPuzzle.fireSwitch = false;
                    break;
                case 2: //ELECTRICITY
                    anim.SetInteger("color", 2);
                    SlimeElementPuzzle.fireSwitch = false;
                    break;
                case 3: //ICE
                    anim.SetInteger("color", 3);
                    SlimeElementPuzzle.fireSwitch = false;
                    break;
            }
            Destroy(other.gameObject);
        }
    }
}
