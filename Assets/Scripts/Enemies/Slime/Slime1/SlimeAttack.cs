using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SlimeAttack : SlimePatrol {

    float dist;
    float distChase=1.5f;
    float waitTimeAttack;
    public float startWaitTimeAttack = 0.2f;
    bool attacking = true;
    float AttackCoolDown = 0.3f;
	// Use this for initialization
	void Start () {
        dmg = 1;
        waitTimeAttack = startWaitTimeAttack;
    }
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        waitTimeAttack = startWaitTimeAttack;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (attacking)
        {
            if (waitTimeAttack <= 0)
            {
                if (InteractionObject.shieldOn == false)
                {
                    GameManager.playerHealth = GameManager.playerHealth - dmg;
                    if (GameManager.playerHealth <= 0)
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                    attacking = false;
                    waitTimeAttack = startWaitTimeAttack;
                    Invoke("AttackAgain", AttackCoolDown);
                }
                
            }
            else
            {
                waitTimeAttack = waitTimeAttack - Time.deltaTime;
            }
           
        }
        else
        {
            waitTimeAttack = startWaitTimeAttack;
        }
       
        dist = (player.transform.position - transform.position).magnitude;
        if (dist > distChase)
        {
            GetComponent<SlimeChase>().enabled = true;
            enabled = false;
        }

    }
    void AttackAgain()
    {
        attacking = true;
    }
}
