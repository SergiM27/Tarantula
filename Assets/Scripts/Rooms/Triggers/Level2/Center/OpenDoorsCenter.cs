using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsCenter : MonoBehaviour {

    public List<GameObject> list;
    private int Count;
    GameObject wall;
    public AudioClip open;
    GameObject chest;
    // Update is called once per frame

    private void Awake()
    {
        wall = GameObject.Find("WallsCenter");
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
            wall.SetActive(false);
            SoundManager.instance.PlaySingle(open);
            this.gameObject.SetActive(false);

        }

    }
}
