using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public static GameObject canvas;
    public static GameObject soundManager;
    public static GameObject eventSystem1;
    public static GameObject eventSystem2;
    public static GameObject player;


    [Space]
    [Header("EnemiesHealth:")]
    public static float batHealth=3.0f;
    public static float bat2Health = 6.0f;
    public static float spiderHealth = 7.0f;
    public static float slimeHealth = 6.0f;
    public static float slime2Health = 8.0f;
    
    

    [Space]
    [Header("BossHealth:")]
    public static float brisingrHealth = 50.0f;
    public static float hermalhoHealth = 100.0f;

    [Space]
    [Header("Keys:")]
    public static bool redKey = false;
    public static bool blueKey = false;
    public static bool yellowKey = false;
    public static bool greenKey = false;

    [Space]
    [Header("Type of Bullet:")]
    public static bool slimeUnlocked = false;
    public static bool electricUnlocked = false;
    public static bool iceUnlocked = false;
    public static bool fireUnlocked = false;

    [Space]
    [Header("Songs:")]
    public static GameObject levelSong;
    public static GameObject bossSong;

    [Space]
    [Header("Stats:")]
    public static int numCoins;
    public static int bulletType;
    public static int playerHealth;

    [Space]
    [Header("Puzzles:")]
    public static bool puzzle1 = false;
    public static bool puzzle2 = false;
    public static bool puzzle3 = false;
    public static bool puzzle4 = false;
    public static bool puzzle5 = false;
    public static bool puzzle6 = false;

    [Space]
    [Header("Inventory:")]
    public static GameObject inventory;

    [Space]
    [Header("Hermalho:")]
    public static bool HermalhoelectricPuzzle = false;
    public static bool HermalhofirePuzzle = false;
    public static bool HermalhoicePuzzle = false;
    public static bool hermalhoShield = true;


    private void Awake()
    {
        player = GameObject.Find("Player");
        bulletType = 1;
        redKey = false;
        inventory = GameObject.Find("Tarantula");
        soundManager = GameObject.Find("SoundManager");
        canvas = GameObject.Find("Canvas");
        eventSystem1 = GameObject.Find("EventSystem1");
        eventSystem2 = GameObject.Find("EventSystem2");
        levelSong = GameObject.Find("Main_Song");
        bossSong = GameObject.Find("Boss_Song");
       
        numCoins = 0;
        playerHealth = 6;
        if (GameObject.Find("GeneralCanvas") == null)
        {
            DontDestroyOnLoad(canvas);
            canvas.gameObject.name = ("GeneralCanvas");
        }
        if (GameObject.Find("TarantulaFinal") == null)
        {
            DontDestroyOnLoad(player);
            player.gameObject.name = ("TarantulaFinal");
        }
        else
        {
            Destroy(GameObject.Find("Player"));
        }
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
        if (GameObject.Find("GameSoundManager") == null)
        {
            DontDestroyOnLoad(soundManager);
            soundManager.gameObject.name = ("GameSoundManager");
        }
        if (GameObject.Find("EventSystem1Final") == null)
        {
            DontDestroyOnLoad(eventSystem1);
            eventSystem1.gameObject.name = ("EventSystem1Final");
        }
        if (GameObject.Find("EventSystem2Final") == null)
        {
            DontDestroyOnLoad(eventSystem2);
            eventSystem2.gameObject.name = ("EventSystem2Final");
        }
    }
}
