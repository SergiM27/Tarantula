using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class PauseMenu : MonoBehaviour {


    private float changeSceneTimer = 0.1f;
    private bool isControlsMenu;
    public static bool gameIsPaused;

    public EventSystem eventsystem1;
    public EventSystem eventsystem2;

    public GameObject menuControls;
    public GameObject menuSettings;
    public GameObject menuPause;
    public GameObject inventory;
    public GameObject panel;
    public static GameObject click_sound;
    public GameObject firstObjectPause;
    public GameObject firstObjectPlay;

    private void Awake()
    {
        eventsystem1.gameObject.SetActive(false);
        eventsystem1.gameObject.SetActive(true);
        gameIsPaused = false;
        menuControls.gameObject.SetActive(false);
        menuPause.gameObject.SetActive(false);
        menuSettings.gameObject.SetActive(false);
       
    }

    private void Start()
    {
        GameObject.Find("EventSystem1Final").GetComponent<EventSystem>().SetSelectedGameObject(null, null);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            if (gameIsPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
            }
        }
        if (isControlsMenu == true)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                BackToPause();
            }
        }
    }

    public void BackToMainMenu()
    {
        Click_Sound();
        Time.timeScale = 1;
        Invoke("ChangeScene", changeSceneTimer);
    }

    public void MenuControls()
    {
        GameObject.Find("EventSystem1Final").GetComponent<EventSystem>().SetSelectedGameObject(null, null);
        Click_Sound();
        menuPause.GetComponent<Animator>().SetInteger("MainMenu", 1);
        menuControls.GetComponent<Animator>().SetInteger("MenuControls", 1);
        isControlsMenu = true;
    }

    public void BackToPause()
    {
        Click_Sound();
        GameObject.Find("EventSystem1Final").GetComponent<EventSystem>().SetSelectedGameObject(firstObjectPause, null);
        menuPause.GetComponent<Animator>().SetInteger("MainMenu", 2);
        menuControls.GetComponent<Animator>().SetInteger("MenuControls", 2);
        isControlsMenu = false;
    }

   public void Resume()
    {
        inventory.gameObject.SetActive(true);
        eventsystem1.gameObject.SetActive(false);
        eventsystem2.gameObject.SetActive(true);
        Click_Sound();
        menuControls.gameObject.SetActive(false);
        menuPause.gameObject.SetActive(false);
        menuSettings.gameObject.SetActive(false);
        panel.SetActive(false);
        GameObject.Find("EventSystem2Final").GetComponent<EventSystem>().SetSelectedGameObject(firstObjectPlay, null);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void Pause()
    {
        inventory.gameObject.SetActive(false);
        eventsystem1.gameObject.SetActive(true);
        eventsystem2.gameObject.SetActive(false);
        menuPause.SetActive(true);
        menuSettings.SetActive(true);
        menuControls.SetActive(true);
        panel.SetActive(true);
        GameObject.Find("EventSystem1Final").GetComponent<EventSystem>().SetSelectedGameObject(firstObjectPause, null);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void Click_Sound()
    {
        click_sound = GameObject.Find("Audio_Click");
        click_sound.gameObject.GetComponent<AudioSource>().Play();
    }


}
