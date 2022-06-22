using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamesIn : MonoBehaviour {

    private GameObject names;
    private string playerTag;

    private void Start()
    {
        playerTag = GameObject.Find("TarantulaFinal").tag;
        names = GameObject.Find("CanvasEasterEggNames");
        names.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            names.gameObject.SetActive(true);
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            names.gameObject.SetActive(false);
        }
    }
}
