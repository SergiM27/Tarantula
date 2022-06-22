using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rufus_Salutation : MonoBehaviour {


    public GameObject rufusBalloon;

    private float ballonOutTimer=2.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
        {
            rufusBalloon.gameObject.GetComponent<Animator>().SetInteger("Rufus", 1);
            Invoke("BallonOut", ballonOutTimer);
        }
        
    }

    public void BallonOut()
    {
        rufusBalloon.gameObject.GetComponent<Animator>().SetInteger("Rufus", 2);
    }
}
