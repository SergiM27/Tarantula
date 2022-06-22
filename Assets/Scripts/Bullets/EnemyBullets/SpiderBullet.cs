using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderBullet : Bullets {

    private GameObject player;
    private Rigidbody2D rb2d;
    private Vector3 target, dir;
    // Use this for initialization
    void Start()
    {
        bulletSpeed = 5.5f;
        enemyDamage = 1;
        bulletDestructionTime = 20.0f;
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        this.gameObject.name = "EnemyBullet";

        if (player != null)
        {
            target = player.transform.position;
            dir = (target - transform.position).normalized;
        }
        Invoke("DestroyBullet", bulletDestructionTime);

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (bulletCDTimer == false)
        {
            Vector2 shootingDirection = new Vector2(dir.x, dir.y);
            shootingDirection.Normalize();
            rb2d.velocity = shootingDirection * bulletSpeed;
            gameObject.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);

        }

    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            DestroyBullet();
        }



        else if (other.gameObject.tag == "Player")
        {
            if (InteractionObject.shieldOn == false)
            {
                GameManager.playerHealth = GameManager.playerHealth - enemyDamage;
                if (GameManager.playerHealth <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
          
        }
    }
}
