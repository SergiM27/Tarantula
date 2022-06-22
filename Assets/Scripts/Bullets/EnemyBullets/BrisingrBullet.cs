using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BrisingrBullet : Bullets {

  
    GameObject player;
    Rigidbody2D rb2d;
    Vector3 target, dir;

    private float brisingrBulletSpeed = 7.0f;
    private int brisingrDamage = 1;
    private float destructionTimeBrisingrBullet = 5.0f;
	// Use this for initialization
	void Start () {
        bulletSpeed = brisingrBulletSpeed;
        enemyDamage = brisingrDamage;
        bulletDestructionTime = destructionTimeBrisingrBullet;
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
	void FixedUpdate () {
        if (bulletCDTimer == false)
        {
            Vector2 shootingDirection = new Vector2(dir.x,dir.y);
            shootingDirection.Normalize();
            rb2d.velocity = shootingDirection * bulletSpeed;
            
        }

    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            DestroyBullet();
        }

        if (collision.gameObject.tag == "Player")
        {
            if (InteractionObject.shieldOn == false)
            {
                GameManager.playerHealth = GameManager.playerHealth - enemyDamage;
                if (GameManager.playerHealth <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                DestroyBullet();
            }
            else
            {
                DestroyBullet();
            }
           
           

        }
    }
}
