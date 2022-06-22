using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rufus_PlaySong : MonoBehaviour {

    public AudioClip rufusSong;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.instance.MusicPlayer(rufusSong);
        }
    }
}
