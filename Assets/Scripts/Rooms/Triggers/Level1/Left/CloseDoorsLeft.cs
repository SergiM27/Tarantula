using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorsLeft : MonoBehaviour {

    public AudioClip close;
    GameObject wall;


    private void Awake()
    {
        wall = GameObject.Find("WallLeftRoom");

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
