using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float speedMax= 4f;
    public float maxPitch = -45f;
    private ParallaxController scr;


    // Use this for initialization


    void Start ()
    {
        scr = GameObject.FindGameObjectWithTag("BackgroundScroller").GetComponent<ParallaxController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float speed = 1.0f;
  
        scr.scrollSpeedX = speed * speedMax;
	}
}
