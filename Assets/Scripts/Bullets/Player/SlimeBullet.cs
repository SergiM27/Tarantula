using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet : Bullets
{
    public AudioClip slimeBullet;

    private void Start()
    {
        SoundManager.instance.RandomizeSfx(slimeBullet);
        this.gameObject.name = "Bullet_Slime";
        playerDamage = 0.65f;
        bulletCDTimer = false;
        bulletSpeed = 8.5f;
        bulletDestructionTime = 2.5f;
        Invoke("DestroyBullet", bulletDestructionTime);
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "BossBullet")
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (bulletCDTimer == false)
        {
            Vector2 shootingDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            shootingDirection.Normalize();
            gameObject.GetComponent<Rigidbody2D>().velocity = shootingDirection * bulletSpeed;
            gameObject.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            bulletCDTimer = true;
            Invoke("BulletCD", bulletDestructionTime);
        }




    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    void BulletCD()
    {
        bulletCDTimer = false;
    }
}
