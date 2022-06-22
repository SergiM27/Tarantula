using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBullet : Bullets
{
    public AudioClip ElecBullet;

    private void Start()
    {
        SoundManager.instance.RandomizeSfx(ElecBullet);
        this.gameObject.name = "Bullet_Electric";
        playerDamage = 0.5f;
        bulletCDTimer = false;
        bulletSpeed = 11.0f;
        bulletDestructionTime = 0.5f;
        Invoke("DestroyBullet", bulletDestructionTime);
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
