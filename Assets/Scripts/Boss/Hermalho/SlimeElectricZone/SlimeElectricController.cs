using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeElectricController : MonoBehaviour {

    public AudioClip correct;
    public static bool firstButton=false;
    public static bool secondButton=false;
    public static bool thirdButton = false;
    private float playSoundTime = 1.0f;

    private void Start()
    {
        firstButton = false;
        secondButton = false;
    }

    void LateUpdate () {
        if (GameManager.HermalhoelectricPuzzle == false)
        {
            if (firstButton && secondButton && thirdButton)
            {
                GameManager.HermalhoelectricPuzzle = true;
                Invoke("PlaySound", playSoundTime);

            }
        }
	}

    void PlaySound()
    {
        SoundManager.instance.PlaySingle(correct);
    }
}
