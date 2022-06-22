using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDownWalls : MonoBehaviour {

    public AudioClip close;
    GameObject wall;
    

    private void Awake()
    {
        wall = GameObject.Find("WallLeftDown");
        
    }
    // Use this for initialization
    void Start () {

        
       
        wall.SetActive(false);

		
	}

    private void FixedUpdate()
    {
        
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
