using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelChanger : MonoBehaviour {

    private float changeSceneTimer = 0.2f;
    public GameObject canvas;

    private GameObject player;
    Vector3 playerPositionBrisingr = new Vector3(-2.9f, 53.5f, 0f);
    private void Start()
    {
        player = GameObject.Find("Tarantula");
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (GameManager.brisingrHealth <= 0)
            {
                player.gameObject.transform.position = playerPositionBrisingr;
            }
        }
        if (GameObject.Find("GeneralCanvas") != null)
        {
            Destroy(GameObject.Find("Canvas"));
        }

    }

    public void ChangeScene1to2()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ChangeScene2to1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            canvas.gameObject.SetActive(true);
            if(Input.GetAxis("X Button") > 0)
            {
                if (this.gameObject.name == "Stair_Level1")
                {
                    other.gameObject.SendMessage("EmptyInventoryBetweenScenes");
                    Invoke("ChangeScene1to2", changeSceneTimer);
                }
                else if (this.gameObject.name == "Stair_Level2")
                {
                    other.gameObject.SendMessage("EmptyInventoryBetweenScenes");
                    Invoke("ChangeScene2to1", changeSceneTimer);
                }
            }
            

        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.gameObject.SetActive(false);
    }



}
