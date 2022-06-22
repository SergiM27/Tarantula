using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimePatrol : EnemyState {

    private Vector3 moveSpot;

    protected GameObject player;

    private int divAmount = 6;

    private float noIceCD=2.0f;

    public float movementSpeedFloat = 1.0f;
    public float rangeVisionFloat = 3.5f;

    public float minX = -10, maxX = 10;
    public float minY = -10, maxY = 10;
    protected Animator anim;
    public Image HealthBar;
    public AudioClip damage;




    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movementSpeed = movementSpeedFloat;
        health = GameManager.slimeHealth;
        
        anim = GetComponent<Animator>();
        moveSpot = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY), 0);
        rangeVision = rangeVisionFloat;

    }

    public void Die()
    {
        //Si no está este void, salta un error del animator
    }

    private void FixedUpdate()
    {

        Vector3 dir = (moveSpot - transform.position).normalized;
        anim.SetFloat("MovX", dir.x);
        anim.SetFloat("Mov.Y", dir.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, rangeVision, 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("IgnoreBullets") | 1 << LayerMask.NameToLayer("RoomLimit"));


        transform.position = Vector2.MoveTowards(transform.position, moveSpot, movementSpeed * Time.deltaTime);
        if (transform.position == moveSpot)
        {
            moveSpot = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY), 0);
        }

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Wall" || hit.collider.tag == "Holes" || hit.collider.tag == "RoomLimit")
            {

                moveSpot = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY), 0);
            }

        }



    }

    private void Update()
    {

        Vector3 Forward = player.transform.position - transform.position;

        float dist = Mathf.Sqrt(Mathf.Pow(Forward.x, 5) + Mathf.Pow(Forward.y, 5));
        if (dist < rangeVision)
        {
            GetComponent<SlimeChase>().enabled = true;
            this.enabled = false;
        }
    }


    public  virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            SoundManager.instance.PlaySingle(damage);
            float dmgDeal = collision.gameObject.GetComponent<Bullets>().GetBulletDmgPlayer();
            health = health - dmgDeal;
            if (HealthBar != null)
            {
                HealthBar.fillAmount = health / divAmount;
            }
          
           
        }
        if (collision.gameObject.name == "Bullet_Ice")
        {
            if (isIce == false)
            {
                movementSpeed = movementSpeed / 2;
                isIce = true;
                Invoke("NoIce", noIceCD);
            }

        }

    }


}
