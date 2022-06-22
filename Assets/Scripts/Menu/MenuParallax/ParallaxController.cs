using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {

    public float scrollSpeedX = 2f;


    private ParallaxSpeedFactor[] psfs;
    private float wBckg;
    private float wCam;

    // Use this for initialization
    void Start ()
    {
        psfs = GetComponentsInChildren<ParallaxSpeedFactor>();
        wBckg = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        wCam = Camera.main.orthographicSize * Camera.main.aspect;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float xLeftCam = Camera.main.transform.position.x - wCam;

        foreach (ParallaxSpeedFactor psf in psfs)
        {
            float deltaX = -scrollSpeedX * Time.deltaTime * psf.speedFactor;

            if ((psf.transform.position.x + wBckg) < xLeftCam)
            {
                psf.transform.Translate(new Vector3(2 * wBckg + deltaX, 0, 0));
            }
            else
            {
                psf.transform.Translate(new Vector3(deltaX, 0, 0));
            }

        }
    }
}
