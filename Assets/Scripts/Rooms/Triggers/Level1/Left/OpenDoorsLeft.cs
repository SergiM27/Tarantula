using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsLeft : MonoBehaviour
{

    public List<GameObject> list;
    GameObject wall;
    private int Count;
    public GameObject key;
    private GameObject spawnP;
    public AudioClip open;
    // Use this for initialization
    private void Awake()
    {
        spawnP = GameObject.Find("BlueKeySpawnP");
        wall = GameObject.Find("WallLeftRoom");
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
            wall.SetActive(false);
            GameObject blueKey = Instantiate(key, spawnP.gameObject.transform.position, Quaternion.identity);
            SoundManager.instance.PlaySingle(open);
            blueKey.gameObject.name = "BlueKey";
            this.gameObject.SetActive(false);
        }

    }
}
