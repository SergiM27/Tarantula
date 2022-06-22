using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch3 : MonoBehaviour
{
    public AudioClip activeSound;
    Color hitColor = new Color32(255, 250, 0, 255);
    private float timer = 1.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet_Electric")
        {
            SoundManager.instance.PlaySingle(activeSound);
            PlatformController3.active = true;
            this.gameObject.GetComponent<SpriteRenderer>().color = hitColor;
            Invoke("BackToOff", timer);
            Destroy(other.gameObject);
        }
    }

    void BackToOff()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
