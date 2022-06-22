using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeChase : SlimePatrol {

    private bool attacking = true;
    Vector3 initialPosition;
    Rigidbody2D rb2d;
    float dist;

    private void OnEnable()
    {
        rangeVisionFloat = 5.0f;
        movementSpeedFloat = 3.0f;
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        rangeVision = rangeVisionFloat;
        movementSpeed = movementSpeedFloat;
    }


    private void FixedUpdate()
    {
        Vector3 target = initialPosition;
        Vector3 Forward = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Forward, rangeVision, 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("IgnoreBullets"));

        Debug.DrawRay(transform.position, Forward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
            }
        }


        Vector3 dir = (target - transform.position).normalized;

        if (target != initialPosition)
        {

            if (attacking)
            {
                rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, target, movementSpeed * Time.deltaTime);
            }

            anim.SetFloat("MovX", dir.x);
            anim.SetFloat("Mov.Y", dir.y);
        }

        else
        {
            GetComponent<SlimePatrol>().enabled = true;
            enabled = false;
        }

       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeVision);
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            float dmgDeal = other.gameObject.GetComponent<Bullets>().GetBulletDmgPlayer();
            health = health - dmgDeal;

            if (health <= -GameManager.slimeHealth)
            {
                
                GetComponent<SlimeDead>().enabled = true;
                enabled = false;
            }
        }
        if (other.gameObject.tag == "Player")
        {
            GetComponent<SlimeAttack>().enabled = true;
            enabled = false;
        }

    }
    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<SlimeAttack>().enabled = true;
            enabled = false;
        }
    }
}
