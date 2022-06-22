using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hermalho_Bullet : Bullets
{
    private Vector2 moveDirection;
    private float moveSpeed;

    private int hermalhoDamage = 1;
    private float destructionTimeHermalhoBullet = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyDamage = hermalhoDamage;
        bulletDestructionTime = destructionTimeHermalhoBullet;

        Invoke("DestroyBullet", bulletDestructionTime);

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

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }


}