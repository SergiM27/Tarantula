using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Initializations
    [Space]

    private static GameObject click_Sound;
    public GameObject menuControls;

    private bool isControlsMenu;
    private float changeSceneTimer = 0.5f;


    //Procedures
    void Awake()
    {
        click_Sound = GameObject.Find("Audio_Click");
        if (SceneManager.GetSceneByName("MainMenu") == SceneManager.GetActiveScene())
        {
            Destroy(GameObject.Find("GeneralCanvas"));
            Destroy(GameObject.Find("GameSoundManager"));
            Destroy(GameObject.Find("EventSystem1Final"));
            Destroy(GameObject.Find("TarantulaFinal"));
            Destroy(GameObject.Find("EventSystem2Final"));
        }
    }

    public void PlayGame()
    {
        Invoke("ChangeScene", changeSceneTimer);
        GameManager.playerHealth = 6;
        GameManager.brisingrHealth = 50;
        GameManager.hermalhoHealth = 100;
        GameManager.numCoins = 0;
        GameManager.blueKey = false;
        GameManager.redKey = false;
        GameManager.yellowKey = false;
        GameManager.greenKey = false;
        GameManager.slimeUnlocked = false;
        GameManager.electricUnlocked = false;
        GameManager.iceUnlocked = false;
        GameManager.fireUnlocked = false;
        GameManager.puzzle1 = false;
        GameManager.puzzle2 = false;
        GameManager.puzzle3 = false;
        GameManager.puzzle4 = false;
        GameManager.puzzle5 = false;
        GameManager.puzzle6 = false;
        Click_Sound();
    }

    public void ExitGame()
    {
        Click_Sound();
        Application.Quit();
    }
    public void MenuControls()
    {
        Click_Sound();
        this.GetComponent<Animator>().SetInteger("MainMenu", 1);
        menuControls.GetComponent<Animator>().SetInteger("MenuControls", 1);
        isControlsMenu = true;
    }
    public void BackToMain()
    {
        Click_Sound();
        this.GetComponent<Animator>().SetInteger("MainMenu", 2);
        menuControls.GetComponent<Animator>().SetInteger("MenuControls", 2);
        isControlsMenu = false;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        if (isControlsMenu == true)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                BackToMain();
            }
        }

    }


    public static void Click_Sound()
    {
        click_Sound = GameObject.Find("Audio_Click");
        click_Sound.gameObject.GetComponent<AudioSource>().Play();
    }

}
