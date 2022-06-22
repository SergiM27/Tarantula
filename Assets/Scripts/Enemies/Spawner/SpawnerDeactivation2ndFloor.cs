using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeactivation2ndFloor : MonoBehaviour {

    public List<Spawner2ndFloor> spawns = new List<Spawner2ndFloor>();
    // Use this for initialization

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Spawner2ndFloor s in spawns)
            {
                s.gameObject.GetComponent<Spawner2ndFloor>().enabled = false;
            }
        }

    }
}
