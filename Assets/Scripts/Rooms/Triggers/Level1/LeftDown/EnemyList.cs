using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour {

    public List<GameObject> list;
    GameObject wall;
    private int Count;

    public AudioClip open;

    // Use this for initialization
    private void Awake()
    {
        wall = GameObject.Find("WallLeftDown");
    }
	
	// Update is called once per frame
	void LateUpdate () {
        Count = 0;
        for (int i = 0; i < list.Count;i++)
        {
            if (list[i] == null) Count++;
        }
        if (Count == list.Count)
        {
            SoundManager.instance.PlaySingle(open);
            wall.SetActive(false);
            this.gameObject.SetActive(false);
        }
		
	}
}
