using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip level2;

	void Start () {
        SoundManager.instance.MusicPlayer(level2);
	}
	
}
