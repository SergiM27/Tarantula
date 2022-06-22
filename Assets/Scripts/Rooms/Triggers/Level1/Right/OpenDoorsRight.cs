using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsRight : MonoBehaviour {

    public List<GameObject> list;
    private int Count;
    public AudioClip open;
    GameObject chest;
    // Update is called once per frame

    private void Awake()
    {
        chest = GameObject.Find("Chest2");
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
            chest.gameObject.SetActive(true);
            SoundManager.instance.PlaySingle(open);
            this.gameObject.SetActive(false);
            
        }

    }
}
