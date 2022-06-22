using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IcePlatform : MonoBehaviour {

    public Transform[] p;

    private string playerTag;
    private GameObject parent;
    public GameObject underground;
    private Rigidbody2D rb2d;
    private float speed = 20.5f;
    public static bool active = false;
    public int initialPosition = 0, nextPosition = 1, totalPosition = 4;

    public Collider2D entrance, exit;

	void Start () {
        parent = GameObject.Find("TarantulaFinal");
        underground = GameObject.Find("UndergroundFirePuzzle");
        rb2d = GetComponent<Rigidbody2D>();
        playerTag = GameObject.Find("TarantulaFinal").tag;
        entrance.enabled = false;
        rb2d.transform.position = p[0].position;
    }
	
	void Update()
    {
      
        if (rb2d.transform.position == p[nextPosition].position) nextPosition++;
        if (nextPosition == totalPosition) nextPosition = initialPosition+1;
        if (rb2d.transform.position == p[initialPosition].position)
        {
            active = false;
            nextPosition++;
        }
            
       

        if (active)

        if (!active)
        {
            entrance.enabled = false;
            IceController.puzzleActive = false;
        }
            
        if (active)
        {
            entrance.enabled = true;
            IceController.puzzleActive = true;
        }
           
            
    }

	void FixedUpdate () {
  
		if (active)
        {
            rb2d.transform.position = Vector3.MoveTowards(rb2d.transform.position, p[nextPosition].position, speed * Time.deltaTime);
        } 

        /*
        if (active)
        {
            if (rb2d.transform.position == p[0].position)
            rb2d.transform.position = Vector3.MoveTowards(rb2d.transform.position, p[1].position, speed * Time.deltaTime);
            if (rb2d.transform.position == p[1].position)
                rb2d.transform.position = Vector3.MoveTowards(rb2d.transform.position, p[2].position, speed * Time.deltaTime);
            if (rb2d.transform.position == p[2].position)
            {
                rb2d.transform.position = Vector3.MoveTowards(rb2d.transform.position, p[3].position, speed * Time.deltaTime);
                active = false;
            }
            if (rb2d.transform.position == p[3].position)
            {
                rb2d.transform.position = Vector3.MoveTowards(rb2d.transform.position, p[0].position, speed * Time.deltaTime);
            }
        }
        */
        
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
}
