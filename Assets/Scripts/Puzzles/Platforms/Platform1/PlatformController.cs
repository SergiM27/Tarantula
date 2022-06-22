using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlatformController : PuzzleTrigger
{

    public float speed = 1f;
    public float startSpeed = 10f;
    public float returnSpeed = 2f;
    public float stopTime = 10f;
    private float timer = 2f;

    public Rigidbody2D platform;
    private string playerTag;

    public Collider2D entrance;
    public Collider2D exit;

    private Transform p1, p2;
    static public bool active = false;
    private bool stop = false;

	void Start ()
    {
        p1 = transform.Find("p1");
        p2 = transform.Find("p2");

        p1.parent = null;
        p2.parent = null;

        playerTag = GameObject.Find("Tarantula").tag;

        entrance.enabled = false;
	}
	

    private void FixedUpdate()
    {
        if (active)
        {
            speed = startSpeed;
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, p1.position, speed * Time.deltaTime);
            if (platform.transform.position == p1.position)
            {
                active = false;
                stop = true;
                exit.enabled = false;
                Invoke("Stop", timer);
            }
                
        }
        else if (stop == false)
        {
            speed = returnSpeed;
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, p2.position, speed * Time.deltaTime);
        }

        if (platform.transform.position == p1.position) exit.enabled = false;
        else if (platform.transform.position == p2.position) entrance.enabled = false;
        else
        {
            entrance.enabled = true;
            exit.enabled = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void Active()
    {
        active = true;
    }

    private void Stop()
    {
        stop = false;
    }
}
