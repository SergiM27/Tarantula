using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour {

    
    protected Rigidbody2D rb2D;
    protected Animator ator;
    protected float health;
    protected int dmg;
    protected float rangeVision;
    public float movementSpeed;
    protected bool isIce = false;
    

    public void InitState()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.isKinematic = true;

        ator = GetComponent<Animator>();


    }

    public virtual void NoIce()
    {
        movementSpeed = movementSpeed * 2;
        isIce = false;
    }
}
