using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderAttack : SpiderIdle
{
    protected Animator anim;

    public GameObject spiderBullet;
    private float CooldownMax = 1.0f;
    bool attacking;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
       
        anim = GetComponent<Animator>();
        health = GameManager.spiderHealth;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 dir = (player.transform.position - transform.position).normalized;
        anim.SetFloat("DirX", dir.x);
        anim.SetFloat("DirY", dir.y);
        if (!attacking) StartCoroutine(Attack(CooldownMax));
        dist = (player.transform.position - transform.position).magnitude;
        if (dist > rangeVision)
        {

            GetComponent<SpiderIdle>().enabled = true;
            this.enabled = false;
        }
    }

    IEnumerator Attack(float CooldownMax)
    {
        attacking = true;

        if ( spiderBullet != null)
        {
            Instantiate(spiderBullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            yield return new WaitForSeconds(CooldownMax);
        }
        attacking = false;
    }



}