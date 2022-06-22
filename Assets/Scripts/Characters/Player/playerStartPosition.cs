using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStartPosition : MonoBehaviour {

    private GameObject player;
    private GameObject player2;
    private Vector3 playerPosition = new Vector3(0f, 0f, 0f);
    private Vector3 playerPosition2 = new Vector3(-4.4f, 2.1f, 0f);

    // Use this for initialization
    void Awake () {
        player = GameObject.Find("TarantulaFinal");
        player2 = GameObject.Find("Tarantula");
    }

    private void Start()
    {
        player.gameObject.transform.position = playerPosition;
        player2.gameObject.transform.position = playerPosition2;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
