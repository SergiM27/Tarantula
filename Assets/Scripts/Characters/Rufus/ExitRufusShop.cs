using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRufusShop : MonoBehaviour {


    public AudioClip levelSong;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.instance.MusicPlayer(levelSong);
        }
    }
}
