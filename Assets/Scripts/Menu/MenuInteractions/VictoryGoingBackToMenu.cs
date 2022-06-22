using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryGoingBackToMenu : MonoBehaviour {

    public AudioClip victorySong;
    private float backToMenu=14.0f;
    // Use this for initialization
    void Start () {
        SoundManager.instance.MusicPlayer(victorySong);
        Invoke("BackToMenu", backToMenu);
	}
	
    void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
