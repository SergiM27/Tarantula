using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderIdle : EnemyState {


    public Image healthBar;
    public float spiderRange = 11.0f;
    protected GameObject player, coin;
    private int divAmount = 7;
    private int hpDeath = -7;
    protected float dist;
    public AudioClip hurt;
    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        rangeVision = spiderRange;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        dist = (player.transform.position - transform.position).magnitude;
        if (dist < rangeVision)
        {

            GetComponent<SpiderAttack>().enabled = true;
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
            if (healthBar != null)
            {
                healthBar.fillAmount = health / divAmount;
            }
            Die();
        }
    }

    public  void Die()
    {
        if (health <= hpDeath)
        {
            GetComponent<SpiderDead>().enabled = true;
            this.enabled = false;
        }
    }
}
