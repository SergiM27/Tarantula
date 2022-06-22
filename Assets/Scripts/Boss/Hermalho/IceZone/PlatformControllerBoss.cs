using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlatformControllerBoss : MonoBehaviour
{

    public AudioClip correct;

    public float speed = 8f;
    public float startSpeed = 8f;
    private float backToSpeedTimer=2f;
    private bool isFreezed=false;
    public Rigidbody2D platform;

    private Transform p1, p2;
    public bool active = true;

    public Color32 icedColor = new Color32(0, 159, 255, 255);

	void Start ()
    {
        GameManager.HermalhoicePuzzle = false;
        p1 = transform.Find("p1BossIce");
        p2 = transform.Find("p2BossIce");

        p1.parent = null;
        p2.parent = null;

    }
	

    private void FixedUpdate()
    {
        if (active)
        {
           
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, p2.position, speed * Time.deltaTime);
            if (platform.transform.position == p2.position)
            {
                active = false;
            }
                
        }
        else
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, p1.position, speed * Time.deltaTime);
            if (platform.transform.position == p1.position)
            {
                active = true;
            }
        }

    }

    private void Active()
    {
        active = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet_Ice")
        {
            if (isFreezed == false)
            {
                speed = 0;
                Destroy(collision.gameObject);
                isFreezed = true;
                this.gameObject.GetComponent<SpriteRenderer>().color = icedColor;
                Invoke("BackToSpeed", backToSpeedTimer);
            }
        }
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "BossBullet")
        {
            if (isFreezed)
            {
                GameManager.HermalhoicePuzzle = true;
                SoundManager.instance.PlaySingle(correct);
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
           
        }
    }

    void BackToSpeed()
    {
        isFreezed = false;
        speed = startSpeed;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
