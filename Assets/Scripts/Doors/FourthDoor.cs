using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthDoor : MonoBehaviour {

    public AudioClip open;
    public GameObject canvas;
    public GameObject secondDoor;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (GameManager.greenKey == true)
        {
            if (other.gameObject.tag == "Player")
            {
                canvas.gameObject.SetActive(true);
                if (Input.GetAxis("X Button") > 0)
                {
                    SoundManager.instance.PlaySingle(open);
                    secondDoor.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(false);
    }
}
