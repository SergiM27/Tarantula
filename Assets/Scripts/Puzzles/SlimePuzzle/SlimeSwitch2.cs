using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSwitch2 : MonoBehaviour {

    public Rigidbody2D barrier;
    Transform p1, p2, currentP;
    float speed = 2f;
    bool active = true;
    public Animator anim;
    public AudioClip correct;

	// Use this for initialization
	void Start () {
        p1 = transform.Find("p1");
        p2 = transform.Find("p2");

        p1.parent = null;
        p2.parent = null;

        currentP = p1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!active)
            return;

        barrier.transform.position = Vector3.MoveTowards(barrier.transform.position, currentP.position, speed * Time.deltaTime);

        float dist = (barrier.transform.position - currentP.position).sqrMagnitude;

        if (dist < Mathf.Epsilon)
        {
            currentP = (currentP == p1 ? p2 : p1);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Slime")
        {
            
            RedKey.secondSwitch = true;
            anim.SetTrigger("ON");
            Destroy(other.gameObject);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            SoundManager.instance.PlaySingle(correct);
        }

    }
}
