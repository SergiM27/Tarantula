using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IcePlatform1 : MonoBehaviour {

    private string playerTag;
    private GameObject parent;
    public GameObject underground;
    public static bool active = false;

    Animator anim;

    public Collider2D entrance, trigger;

	void Start () {
        parent = GameObject.Find("TarantulaFinal");
        underground = GameObject.Find("UndergroundFirePuzzle");
        playerTag = GameObject.Find("TarantulaFinal").tag;
        entrance.enabled = false;
        anim = GetComponent<Animator>();
    }
	
	void Update()
    {
        if (active)
        {
            entrance.enabled = true;
            IceController.puzzleActive = true;
            anim.SetBool("active", true);
            
        }
        else
        {
            Deactivate();
            entrance.enabled = false;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == playerTag)
        {
            other.gameObject.transform.parent = transform;
            underground.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == playerTag)
        {
            other.gameObject.transform.parent = parent.transform;
            underground.gameObject.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }

    void Deactivate()
    {
        anim.SetBool("active", false);
        active = false;
        IceController.puzzleActive = false;
        
    }
}
