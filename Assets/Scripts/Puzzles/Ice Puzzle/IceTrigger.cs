using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrigger : MonoBehaviour {

    string playerTag = "Player";

	void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == playerTag)
        {
            IcePlatform1.active = false;
        }
    }
}
