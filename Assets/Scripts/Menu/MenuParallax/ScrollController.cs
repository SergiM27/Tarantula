using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{

    public float scrollSpeedX = 2f;

    private SpriteRenderer[] sprs;
    private float wCam;
    private float wBckg;

    // Use this for initialization


    void Start ()
    {
        sprs = GetComponentsInChildren<SpriteRenderer>();
        wCam = Camera.main.orthographicSize * Camera.main.aspect;
        wBckg = sprs[0].bounds.size.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float xLeftCam = Camera.main.transform.position.x - wCam;

		foreach(SpriteRenderer spr in sprs)
        {
            float deltaX = -scrollSpeedX * Time.deltaTime;

            if ((spr.transform.position.x + wBckg)< xLeftCam)
            {
                spr.transform.Translate(new Vector3(2*wBckg + deltaX, 0, 0));
            }
            else
            {
                spr.transform.Translate(new Vector3(deltaX, 0, 0));
            }

        }
	}
}
