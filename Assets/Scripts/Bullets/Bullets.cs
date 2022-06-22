using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    protected float bulletSpeed;
    protected int bulletType;
    protected float bulletDestructionTime;
    protected bool bulletCDTimer;
    protected int enemyDamage;
    public float playerDamage;
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "MapProp" 
            || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BossBullet")

        {
            Destroy(this.gameObject);
        }
    }
    public virtual float GetBulletDmgPlayer()
    {
        return playerDamage;
    }
    public virtual int GetBulletDmgEnemy()
    {
        return enemyDamage;
    }


}
