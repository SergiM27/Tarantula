using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hermalho : EnemyState
{

    public Vector3 moveSpot;

    protected GameObject player;
    public Image HealthBar;
    public AudioClip death;
    public AudioClip shieldBreak;


    private int divAmount = 100;

    public float timeToVictory = 4.0f;
    private float hermalhoMovSpeed=3.5f;
    public float hermalhoRangeVision = 2.5f;

    protected float minX = -10, maxX = 10;
    protected float minY = -10, maxY = 10;
    protected Animator anim;



    // Use this for initialization
    void Start()
    {
        movementSpeed = hermalhoMovSpeed;
        health = GameManager.hermalhoHealth;
        moveSpot = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY), 0);
        player = GameObject.FindGameObjectWithTag("Player");
        rangeVision = hermalhoRangeVision;

    }

    private void FixedUpdate()
    {

        Vector3 dir = (moveSpot - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, rangeVision, 1 << LayerMask.NameToLayer("RoomLimit"));


        transform.position = Vector2.MoveTowards(transform.position, moveSpot, movementSpeed * Time.deltaTime);
        if (transform.position == moveSpot)
        {
            moveSpot = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY), 0);
        }

        if (hit.collider != null)
        {
            if (hit.collider.tag == "RoomLimit")
            {

                moveSpot = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY), 0);
            }

        }

        if (HealthBar != null)
        {
            HealthBar.fillAmount = health / divAmount;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.hermalhoShield == false)
        {
            if (collision.gameObject.tag == "PlayerBullet")
            {
                float dmgDeal = collision.gameObject.GetComponent<Bullets>().GetBulletDmgPlayer();
                health = health - dmgDeal;
                GameManager.hermalhoHealth = health;
                Destroy(collision.gameObject);
            }
        }
    }


}
