using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour {


    private static GameObject click_Sound;
    private float changeSceneTimer = 0.1f;
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        click_Sound = GameObject.Find("Audio_Click");

        if (SceneManager.GetSceneByName("GameOver") == SceneManager.GetActiveScene())
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
        GameManager.playerHealth = 6;
        GameManager.brisingrHealth = 50;
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
        Invoke("Play",changeSceneTimer);
        Click_Sound();
    }

    public void ExitGame()
    {
        Click_Sound();
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene(2);  
    }
    public void BackToMenu()
    {
        Click_Sound();
        SceneManager.LoadScene(1);
    }

    public static void Click_Sound()
    {
        click_Sound = GameObject.Find("Audio_Click");
        click_Sound.gameObject.GetComponent<AudioSource>().Play();
    }

}
