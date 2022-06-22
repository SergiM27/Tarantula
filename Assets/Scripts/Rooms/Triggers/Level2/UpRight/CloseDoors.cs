using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoors : MonoBehaviour {

    GameObject wall;
    public AudioClip close;

    private void Awake()
    {
        wall = GameObject.Find("WallsUpRight");
    }
    // Use this for initialization
    void Start()
    {
        wall.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.instance.PlaySingle(close);
            wall.SetActive(true);
            this.gameObject.SetActive(false);

        }

    }
}
