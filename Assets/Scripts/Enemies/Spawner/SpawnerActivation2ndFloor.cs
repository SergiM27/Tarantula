using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivation2ndFloor : MonoBehaviour {


    public List<Spawner2ndFloor> spawns = new List<Spawner2ndFloor>();
    // Use this for initialization
    void Start () {
        foreach(Spawner2ndFloor s in spawns)
        {
            s.gameObject.GetComponent<Spawner2ndFloor>().enabled=false;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Spawner2ndFloor s in spawns)
            {
                s.gameObject.GetComponent<Spawner2ndFloor>().enabled = true;
            }
        }
       
    }
}
