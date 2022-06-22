using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {

    public List<GameObject> list;
    private int Count;
    GameObject wall;
    GameObject wallPuzzle;
    public AudioClip open;
    GameObject chest;
    // Update is called once per frame

    private void Awake()
    {
        wall = GameObject.Find("WallsUpRight");
        wallPuzzle = GameObject.Find("WallDownPuzzle");
        chest = GameObject.Find("Chest2ndFloorIce");
    }

    private void Start()
    {
        chest.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        Count = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null) Count++;
        }
        if (Count == list.Count)
        {
            wallPuzzle.SetActive(false);
            wall.SetActive(false);
            SoundManager.instance.PlaySingle(open);
            chest.gameObject.SetActive(true);
            this.gameObject.SetActive(false);

        }

    }
}
