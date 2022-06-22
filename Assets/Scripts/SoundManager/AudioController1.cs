using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController1 : MonoBehaviour {

    public AudioClip level2;
    public AudioClip shop;
    string playerTag = "Player";

    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == playerTag)
        {
            SoundManager.instance.MusicPlayer(shop);
        }
    }

}
