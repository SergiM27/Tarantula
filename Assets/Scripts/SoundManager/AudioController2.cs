using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController2 : MonoBehaviour {

    public AudioClip level2;
    public AudioClip shop;
    string playerTag = "Player";


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == playerTag)
        {
            SoundManager.instance.MusicPlayer(level2);
        }
    }

}
