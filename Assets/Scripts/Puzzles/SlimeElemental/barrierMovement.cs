using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierMovement : MonoBehaviour {

    Transform p1, p2;
    float speed = 0.5f;
    bool active = true;

	void Start () {
        p1 = transform.Find("p1");
        p2 = transform.Find("p2");

        p1.parent = null;
        p2.parent = null;
    }

    private void FixedUpdate()
    {
        if (active)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, p1.position, speed * Time.deltaTime);
            if (gameObject.transform.position == p1.position)
                active = false;
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, p2.position, speed * Time.deltaTime);
            if (gameObject.transform.position == p2.position)
                active = true;
        }

    }
}
