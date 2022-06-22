using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrisingrState : MonoBehaviour {

    protected Rigidbody2D rb2D;
    protected Animator ator;

    public void InitState()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.isKinematic = true;

        ator = GetComponent<Animator>();


    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            float dmgDeal= collision.gameObject.GetComponent<Bullets>().GetBulletDmgPlayer();
            GameManager.brisingrHealth = GameManager.brisingrHealth - dmgDeal;
            print(GameManager.brisingrHealth);
        }
        
    }
}
