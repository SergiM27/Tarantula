using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
public class SettingsMenu : MonoBehaviour {

    // Use this for initialization
    private GameObject volumeSlider;

    public GameObject mainMenu;

    private bool isSettingsOpen = true;

    public GameObject firstObjectSettings;
    public GameObject firstObjectMain;
    public GameObject canvasOff;
    public GameObject canvasOn;

    private float initialVol=0.75f;


    public void Switch()
    {
        SettingButton();
    }


    private void Awake()
    {
        Screen.fullScreen = true;
        volumeSlider = GameObject.Find("VolumeSlider");
    }

    public void Start()
    {
        volumeSlider.gameObject.GetComponent<Slider>().value = initialVol;
    }

   
    public void SetFullScreen(bool isFullScreen)
    {
        PauseMenu.Click_Sound();
        Screen.fullScreen = isFullScreen;

    }

    public void Volume_Change()
    {
        AudioListener.volume = volumeSlider.gameObject.GetComponent<Slider>().value;
    }

    public void SettingButton()
    {
        if (isSettingsOpen == false)
        {
            this.gameObject.GetComponent<Animator>().SetInteger("IsSettingsIn", 2);
            mainMenu.gameObject.GetComponent<Animator>().SetInteger("MainMenu", 4);
            isSettingsOpen = true;
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstObjectMain, null);
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetInteger("IsSettingsIn", 1);
            mainMenu.gameObject.GetComponent<Animator>().SetInteger("MainMenu", 3);
            isSettingsOpen = false;
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstObjectSettings, null);
        }
        PauseMenu.Click_Sound();
    }
}
