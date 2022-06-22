using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsController1stFloor : MonoBehaviour {

    private GameObject door1;
    private GameObject door2;
    private GameObject door3;
    private GameObject door4;
    private void Awake()
    {
        door1 = GameObject.Find("1stDoor");
        door2 = GameObject.Find("2ndDoor");
    }
    void Start () {
        if (GameManager.redKey == true)
        {
            door1.gameObject.SetActive(false);
        }
        if (GameManager.blueKey== true)
        {
            door2.gameObject.SetActive(false);
        }
    }
}
