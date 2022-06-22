using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewShield : MonoBehaviour {

    public GameObject shield;


	public void SpawnShield()
    {
        Instantiate(shield, this.gameObject.transform.position, Quaternion.identity);
    }

}
