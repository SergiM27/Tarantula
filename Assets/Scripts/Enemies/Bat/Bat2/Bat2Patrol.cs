using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bat2Patrol : EnemyState {

    public Vector3 moveSpot;

    protected GameObject player;

    public float bat2MovementSpeed = 2.0f;
    public float bat2RangeVision = 6.5f;
    private int divAmount = 3;
    private int hpDeath = -3;

    protected float minX = -10, maxX = 10;
    protected float minY = -10, maxY = 10;
    protected Animator anim;
    public Image HealthBar;

    public AudioClip hurt;

    // Use this for initialization
    void Start()
    {
        movementSpeed = bat2MovementSpeed;
        health = GameManager.batHealth;
        anim = GetComponent<Animator>();
        moveSpot = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY), 0);
        rangeVision = bat2RangeVision;
        player = GameObject.FindGameObjectWithTag("Player");


    }

    private void FixedUpdate()
    {

        Vector3 dir = (moveSpot - transform.position).normalized;
        anim.SetFloat("MovX", dir.x);
        anim.SetFloat("MovY", dir.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, rangeVision, 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("RoomLimit"));
        Vector3 Forward = player.transform.position - transform.position;


        transform.position = Vector2.MoveTowards(transform.position, moveSpot, movementSpeed * Time.deltaTime);
        if (transform.position == moveSpot)
        {
            moveSpot = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY), 0);
        }

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Wall" || hit.collider.tag == "RoomLimit")
            {

                moveSpot = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY), 0);
            }

        }


        float dist = Mathf.Sqrt(Mathf.Pow(Forward.x, 2) + Mathf.Pow(Forward.y, 2));
        if (dist < rangeVision)
        {
            GetComponent<Bat2Chase>().enabled = true;
            this.enabled = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            SoundManager.instance.PlaySingle(hurt);
            float dmgDeal = collision.gameObject.GetComponent<Bullets>().GetBulletDmgPlayer();
            health = health - dmgDeal;
            if (HealthBar != null)
            {
                HealthBar.fillAmount = health / divAmount;

            }

            if (health <= hpDeath)
            {
                GetComponent<Bat2Dead>().enabled = true;
                enabled = false;
            }


        }
        if (collision.gameObject.name == "Bullet_Ice")
        {
            if (isIce == false)
            {
                movementSpeed = movementSpeed / 2;
                isIce = true;
                Invoke("NoIce", 2.0f);
            }

        }

    }
}
