using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleTriggerIce : MonoBehaviour {


    public GameObject underground;
    private string playerTag;

    private void Start()
    {
        playerTag = GameObject.Find("TarantulaFinal").tag;
        underground = GameObject.Find("UndergroundFirePuzzle");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
            if (other.gameObject.tag == playerTag)
            {
                underground.GetComponent<TilemapCollider2D>().enabled = true;
            }
    }
}
