using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullets
{
    public AudioClip iceBullet;

    private void Start()
    {
        SoundManager.instance.RandomizeSfx(iceBullet);
        this.gameObject.name = "Bullet_Ice";
        playerDamage = 0.75f;
        bulletCDTimer = false;
        bulletSpeed = 5.0f;
        bulletDestructionTime = 3.0f;
        Invoke("DestroyBullet", bulletDestructionTime);
    }
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Wall" || other.gameObject.tag == "MapProp" 
            || other.gameObject.tag == "BossBullet" )
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
