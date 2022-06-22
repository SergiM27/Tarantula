using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleTrigger : MonoBehaviour {

    public AudioClip puzzleCompleted;

    public GameObject undergroundCollider;
    private GameObject player;
    private GameObject puzzleText;
    private float imageNewObjectTime = 3.0f;


    void Start () {
        puzzleText = GameObject.Find("PuzzleCompletedText");
        player = GameObject.Find("TarantulaFinal");
        undergroundCollider = GameObject.Find("Underground");
        undergroundCollider.GetComponent<TilemapCollider2D>().enabled = true;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.name == "Trigger1" || this.gameObject.name == "Trigger2") {
            if (collision.gameObject.tag == ("Player"))
            {
                undergroundCollider.GetComponent<TilemapCollider2D>().enabled = true;
            }
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.gameObject.name == "Trigger1")
        {
            if (collision.gameObject.tag == ("Player"))
            {
                undergroundCollider.GetComponent<TilemapCollider2D>().enabled = false;
            }
        }
        if (this.gameObject.name == "Trigger2")
        {
            if (collision.gameObject.tag == ("Player"))
            {
                collision.transform.parent = player.transform;
                undergroundCollider.GetComponent<TilemapCollider2D>().enabled = true;
            }
        }
        if (this.gameObject.name == "Trigger3")
        {
            if (collision.gameObject.tag == ("Player"))
            {
                collision.transform.parent = player.transform;
                undergroundCollider.GetComponent<TilemapCollider2D>().enabled = true;
            }
        }
        if (this.gameObject.name == "Trigger4")
        {
            if (collision.gameObject.tag == ("Player"))
            {
                if(GameManager.puzzle3==false)
                {
                    SoundManager.instance.PlaySingle2(puzzleCompleted);
                    puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 1);
                    Invoke("PuzzleCompletedOut", imageNewObjectTime);
                    GameManager.puzzle3 = true;
                }
                collision.transform.parent = player.transform;
                undergroundCollider.GetComponent<TilemapCollider2D>().enabled = true;
            }
        }


    }
    void PuzzleCompletedOut()
    {
        puzzleText.gameObject.GetComponent<Animator>().SetInteger("PuzzleCompleted", 2);
    }
}
