using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsDown : MonoBehaviour {

    public List<GameObject> list;
    GameObject wall;
    GameObject chest;
    private int Count;
    public AudioClip open;

    // Use this for initialization
    private void Awake()
    {
        wall = GameObject.Find("WallDownRoom");
        chest = GameObject.Find("Chest1");
        chest.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Count = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null) Count++;
        }
        if (Count == list.Count)
        {
            SoundManager.instance.PlaySingle(open);
            chest.gameObject.SetActive(true);
            wall.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }
}
