using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlatform2 : MonoBehaviour {

    public Rigidbody2D barrier;
    Transform p1, p2;
    float speed, activeSpeed = 5f, returnSpeed = 2f;
    public Animator anim;
    public AudioClip correct;
    float dist;

    public static bool active = false;

    // Use this for initialization
    void Start()
    {
        p1 = transform.Find("p1");
        p2 = transform.Find("p2");

        p1.parent = null;
        p2.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (active) speed = activeSpeed;
        else speed = returnSpeed;
        if (barrier.transform.position == p1.position) active = false;
    }

    void FixedUpdate()
    {
        if (active)
        {
            barrier.transform.position = Vector3.MoveTowards(barrier.transform.position, p1.position, speed * Time.deltaTime);
        }
        else
        {
            barrier.transform.position = Vector3.MoveTowards(barrier.transform.position, p2.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Slime")
        {
            SoundManager.instance.PlaySingle(correct);
            YellowKeyController.secondSwitch = true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            anim.SetTrigger("ON");
            Destroy(other.gameObject);
        }

    }
}
