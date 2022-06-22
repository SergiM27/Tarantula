using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossManager : MonoBehaviour
{
    private float timeToVictory = 5.0f;
    public float shieldTimeOff = 15.0f;
    private GameObject hermalhoShield;

    public GameObject hermalho;

    private bool hermalhoIsDead = false;
    private bool puzzlesDone = false;

    public GameObject shield;
    public GameObject spawnPointShield;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;
    public GameObject torch4;
    public GameObject torch5;
    public GameObject torch6;
    public GameObject torch7;
    public GameObject torch8;
    public GameObject torch9;

    int i;

    public AudioClip death;
    public AudioClip shieldBreak;


    // Use this for initialization
    void Start()
    {
        hermalhoShield = GameObject.Find("HermalhoShield");
        hermalhoShield.gameObject.SetActive(true);
        GameManager.HermalhoelectricPuzzle = false;
        GameManager.HermalhofirePuzzle = false;
        GameManager.HermalhoicePuzzle = false;
        GameManager.hermalhoShield = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (hermalhoIsDead == false)
        {
            if (puzzlesDone == false)
            {
                if (GameManager.HermalhoelectricPuzzle == true && GameManager.HermalhofirePuzzle && GameManager.HermalhoicePuzzle == true)
                {
                    SoundManager.instance.PlaySingle2(shieldBreak);
                    hermalhoShield.gameObject.SetActive(false);
                    GameManager.hermalhoShield = false;
                    Invoke("ShieldIn", shieldTimeOff);
                    puzzlesDone = true;
                }
            }
            if (GameManager.hermalhoHealth <= 0)
            {
                SoundManager.instance.PlaySingle(death);
                Destroy(hermalho.gameObject);
                hermalhoIsDead = true;
                Invoke("GoToVictory", timeToVictory);
            }
        }


    }

    void ShieldIn()
    {
        hermalhoShield.gameObject.SetActive(true);
        GameManager.HermalhoelectricPuzzle = false;
        GameManager.HermalhofirePuzzle = false;
        GameManager.HermalhoicePuzzle = false;
        GameManager.hermalhoShield = true;
        puzzlesDone = false;
        SpawnShield();
        Button1OffAgain();
        Button2OffAgain();
        Button3OffAgain();
        RandomAgainTorch1();
        RandomAgainTorch2();
        RandomAgainTorch3();
        RandomAgainTorch4();
        RandomAgainTorch5();
        RandomAgainTorch6();
        RandomAgainTorch7();
        RandomAgainTorch8();
        RandomAgainTorch9();
    }


    void GoToVictory()
    {
        SceneManager.LoadScene(5);
    }

    public void SpawnShield()
    {
        Instantiate(shield, spawnPointShield.gameObject.transform.position, Quaternion.identity);
        GameManager.HermalhoicePuzzle = false;
    }

    public void Button1OffAgain()
    {
        SlimeElectricController.firstButton = false;
        button1.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        button1.gameObject.GetComponent<Animator>().SetBool("ON", false);
    }
    public void Button2OffAgain()
    {
        SlimeElectricController.secondButton = false;
        button2.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        button2.gameObject.GetComponent<Animator>().SetBool("ON", false);
    }
    public void Button3OffAgain()
    {
        SlimeElectricController.thirdButton = false;
        button3.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        button3.gameObject.GetComponent<Animator>().SetBool("ON",false);
    }
    public void RandomAgainTorch1()
    {
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch1 = true;
            torch1.gameObject.GetComponent<Animator>().SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch1 = false;
            torch1.gameObject.GetComponent<Animator>().SetBool("lit", false);
        }
    }
    public void RandomAgainTorch2()
    {
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch2 = true;
            torch2.gameObject.GetComponent<Animator>().SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch2 = false;
            torch2.gameObject.GetComponent<Animator>().SetBool("lit", false);
        }
    }
    public void RandomAgainTorch3()
    {
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch3 = true;
            torch3.gameObject.GetComponent<Animator>().SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch3 = false;
            torch3.gameObject.GetComponent<Animator>().SetBool("lit", false);
        }
    }
    public void RandomAgainTorch4()
    {
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch4 = true;
            torch4.gameObject.GetComponent<Animator>().SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch4 = false;
            torch4.gameObject.GetComponent<Animator>().SetBool("lit", false);
        }
    }
    public void RandomAgainTorch5()
    {
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch5 = true;
            torch5.gameObject.GetComponent<Animator>().SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch5 = false;
            torch5.gameObject.GetComponent<Animator>().SetBool("lit", false);
        }
    }
    public void RandomAgainTorch6()
    {
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch6 = true;
            torch6.gameObject.GetComponent<Animator>().SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch6 = false;
            torch6.gameObject.GetComponent<Animator>().SetBool("lit", false);
        }
    }
    public void RandomAgainTorch7()
    {
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch7 = true;
            torch7.gameObject.GetComponent<Animator>().SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch7 = false;
            torch7.gameObject.GetComponent<Animator>().SetBool("lit", false);
        }
    }
    public void RandomAgainTorch8()
    {
        i = Random.Range(0, 2);
        if (i == 1)
        {
            FireZoneManager.fireZoneTorch8 = true;
            torch8.gameObject.GetComponent<Animator>().SetBool("lit", true);
        }
        else
        {
            FireZoneManager.fireZoneTorch8 = false;
            torch8.gameObject.GetComponent<Animator>().SetBool("lit", false);
        }
    }
    public void RandomAgainTorch9()
    {
        FireZoneManager.fireZoneTorch9 = false;
        torch9.gameObject.GetComponent<Animator>().SetBool("lit", false);
    }

}
