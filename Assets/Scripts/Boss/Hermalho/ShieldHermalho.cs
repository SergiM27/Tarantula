﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHermalho : MonoBehaviour {

    // Use this for initialization

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
