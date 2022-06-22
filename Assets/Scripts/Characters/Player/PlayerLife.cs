using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    bool invencibility = false;
    float invencibilityTimer = 1f;

    public AudioClip damage;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (invencibility == false)
        {
            if (other.CompareTag("EnemyBullet"))
            {
                SoundManager.instance.PlaySingle(damage);
                int dmgDeal = other.gameObject.GetComponent<Bullets>().GetBulletDmgEnemy();
                GameManager.playerHealth = GameManager.playerHealth - dmgDeal;
                invencibility = true;
                Invoke("InvencibilityCD", invencibilityTimer);
            }
        }
    }

    void InvencibilityCD()
    {
        invencibility = false;
    }
}
