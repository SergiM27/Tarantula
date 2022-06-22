using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorsBoss : MonoBehaviour {

    GameObject wall;
    GameObject boss;
    private GameObject ShowHealth;
    public AudioClip finalBoss;
    public AudioClip close;
    public AudioClip laugh;
    string playerTag = "Player";

    private void Awake()
    {
        wall = GameObject.Find("WallBossH");
        boss = GameObject.Find("Hermalho");
        boss.gameObject.GetComponent<BulletsHermalho>().enabled = false;
        ShowHealth = GameObject.Find("HermalhoHealthBar");
        ShowHealth.gameObject.SetActive(false);
    }

    void Start()
    {
        ShowHealth.gameObject.SetActive(false);
        wall.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            SoundManager.instance.PlaySingle(close);
            SoundManager.instance.PlaySingle2(laugh);
            SoundManager.instance.MusicPlayer(finalBoss);
            ShowHealth.gameObject.SetActive(true);
            wall.SetActive(true);
            this.gameObject.SetActive(false);
            boss.gameObject.GetComponent<BulletsHermalho>().enabled = true;

        }

    }
}
