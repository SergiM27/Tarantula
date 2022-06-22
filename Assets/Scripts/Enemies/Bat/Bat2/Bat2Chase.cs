using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat2Chase : Bat2Patrol {

    public float initspeed;
    public float batRangeVision = 5.5f;
    Vector3 initialPosition, target;
    private Rigidbody2D rb2d;
    public GameObject BatAttack;
    private float CooldownMax = 1.0f;
    private float offsetBullet = 0.4f;
    private float MinDist = 1.0f;
    private float speed;
    bool attacking;
    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        rangeVision = batRangeVision;
        speed = initspeed;


    }

    // Update is called once per frame
    void Update()
    {



    }

    private void FixedUpdate()
    {
        target = initialPosition;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, rangeVision, 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Wall"));
        Vector3 Forward = player.transform.position - transform.position;
        Debug.DrawRay(transform.position, Forward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
            }
        }


        Vector3 dir = (target - transform.position).normalized;

        if (target != initialPosition && BatAttack != null)
        {
            // transform.position = transform.position + Forward * speed * Time.deltaTime;
            rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, target, speed * Time.deltaTime);

            anim.SetFloat("MovX", dir.x);
            anim.SetFloat("MovY", dir.y);

            float dist = (target - transform.position).magnitude;
            if (dist < MinDist)
            {
                speed = 0.0f;
            }
            else speed = initspeed;

            if (!attacking) StartCoroutine(Attack(CooldownMax));

        }

        else
        {
            GetComponent<Bat2Patrol>().enabled = true;
            enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeVision);
    }

    IEnumerator Attack(float CooldownMax)
    {
        attacking = true;

        if (target != initialPosition && BatAttack != null)
        {
            Instantiate(BatAttack, new Vector3(transform.position.x, transform.position.y + offsetBullet, 0), transform.rotation);
            yield return new WaitForSeconds(CooldownMax);
        }
        attacking = false;
    }

}
