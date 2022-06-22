using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivation1stFloor : MonoBehaviour {


    public List<Spawner1stFloor> spawns = new List<Spawner1stFloor>();
    // Use this for initialization
    void Start () {
        foreach(Spawner1stFloor s in spawns)
        {
            s.gameObject.GetComponent<Spawner1stFloor>().enabled=false;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Spawner1stFloor s in spawns)
            {
                s.gameObject.GetComponent<Spawner1stFloor>().enabled = true;
            }
        }
       
    }
}
