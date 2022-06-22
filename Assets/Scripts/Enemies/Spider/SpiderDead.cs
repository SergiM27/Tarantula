using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDead : MonoBehaviour {


    public AudioClip death;

    private void Start()
    {
        SoundManager.instance.PlaySingle(death);
        Destroy(this.gameObject);
    }

  
}
