using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brisingr : BrisingrState
{
    public AudioClip bossTheme;
    public AudioClip level1Theme;
    public Image HealthBar;

    public static bool startBossFight1 = false;
    private bool changeFase = false;
    private bool rightMovement = true;
    private bool shooting = true;
    private bool startShooting = true;
    private float totalhealth = 50.0f;
    private int numBullets = 0;

    public Rigidbody2D brisingrRB2D;
    public Rigidbody2D playerRB2D;

    private Color fase2Brisingr = new Color32(255, 247, 97, 255);
    private Color fase3Brisingr = new Color32(255, 100, 100, 255);
    private Color fase3Bullet = new Color32(0, 255, 88, 255);
    private Color fase4Bullet = new Color32(255, 187, 0, 255);
    private Color fase1HealthBar = new Color32(68, 209, 84, 255);
    private Color fase3HealthBar = new Color32(31, 121, 42, 255);

    public GameObject brisingrBullet;
    private GameObject limitLeft, limitRight;
    private GameObject stairs;
    private GameObject bossWall;
    private GameObject ShowHealth;

    private SpriteRenderer bulletSR;
    private SpriteRenderer brisingrSR;

    private float currentSpeed = 0f;
    private float shootTimer = 1.0f;

    List<float> faseMovSpeed = new List<float> { 0.07f, 0.08f, 0.09f, 0.14f };
    List<float> faseLife = new List<float> { 30f, 20f, 10f };

    public AudioClip proyectil;
    public AudioClip death;

    private void Awake()
    {
        bossWall = GameObject.Find("BossWall");
        ShowHealth = GameObject.Find("BrisingrHealthBarCanvas");


    }
    void Start()
    {
        startBossFight1 = false;
        stairs = GameObject.Find("Stair_Level1");
        stairs.gameObject.SetActive(false);
        
       
        bulletSR = brisingrBullet.gameObject.GetComponent<SpriteRenderer>();
        bulletSR.color = Color.white;
        brisingrSR = GetComponent<SpriteRenderer>();
        limitLeft = GameObject.Find("LeftLimit");
        limitRight = GameObject.Find("RightLimit");
        InvokeRepeating("Shoot", 0.0f, shootTimer);
    }

    void Update()
    {
        FaseChange();
        
    }



    void FixedUpdate()
    {
        if (startBossFight1)
        {
            if (changeFase == false)
            {
                FaseFollowPlayer();
            }

            else
            {
                FaseAutomaticMovement();
            }

        }
    }

    void FaseChange()
    {
        Die();
        CheckFase();


    }

    void CheckFase()
    {
        if (GameManager.brisingrHealth > faseLife[0])
        {
            HealthBar.color = fase1HealthBar;
            currentSpeed = faseMovSpeed[0];
        }
        else if (GameManager.brisingrHealth > faseLife[1])
        {
            HealthBar.color= Color.yellow;
            brisingrSR.color = fase2Brisingr;
            bulletSR.color = Color.yellow;
            currentSpeed = faseMovSpeed[1];
            isChangeFase();
        }
        else if (GameManager.brisingrHealth > faseLife[2])
        {
            HealthBar.color = fase3HealthBar;
            brisingrSR.color = fase3Brisingr;
            bulletSR.color = fase3Bullet;
            currentSpeed = faseMovSpeed[2];
        }
        else
        {
            HealthBar.color = Color.red;
            brisingrSR.color = Color.red;
            bulletSR.color = fase4Bullet;
            currentSpeed = faseMovSpeed[3];
        }

        if (HealthBar != null)
        {
            HealthBar.fillAmount = GameManager.brisingrHealth / totalhealth;
        }
    }

    public void Die()
    {
        if (GameManager.brisingrHealth <= 0)
        {
            SoundManager.instance.PlaySingle(death);
            bossWall.gameObject.SetActive(false);
            ShowHealth.gameObject.SetActive(false);
            SoundManager.instance.MusicPlayer(level1Theme);
            stairs.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    void FaseFollowPlayer()
    {
        if ((brisingrRB2D.position.x - playerRB2D.position.x < 0.1f) && (brisingrRB2D.position.x - playerRB2D.position.x > -0.1f))
            brisingrRB2D.position = new Vector3(brisingrRB2D.position.x, brisingrRB2D.position.y, 0);
        else if ((brisingrRB2D.position.x < playerRB2D.position.x) && (brisingrRB2D.position.x < limitRight.transform.position.x))
            brisingrRB2D.position = new Vector3(brisingrRB2D.position.x + currentSpeed, brisingrRB2D.position.y, 0);
        else if ((brisingrRB2D.position.x > playerRB2D.position.x) && (brisingrRB2D.position.x > limitLeft.transform.position.x))
            brisingrRB2D.position = new Vector3(brisingrRB2D.position.x - currentSpeed, brisingrRB2D.position.y, 0);
    }

    void FaseAutomaticMovement()
    {

        if (rightMovement == false)
        {
            if (brisingrRB2D.position.x > limitLeft.transform.position.x)
            {
                Vector2 moveDirection = new Vector2(brisingrRB2D.position.x - currentSpeed, 0);
                moveDirection.Normalize();
                gameObject.GetComponent<Rigidbody2D>().velocity = moveDirection * currentSpeed;
                brisingrRB2D.position = new Vector3(brisingrRB2D.position.x - currentSpeed, brisingrRB2D.position.y, 0);
            }
            else
            {
                rightMovement = true;
            }
        }
        else if (rightMovement == true)
        {
            if (brisingrRB2D.position.x <= limitRight.transform.position.x)
            {
                Vector2 moveDirection = new Vector2(brisingrRB2D.position.x + currentSpeed, 0);
                moveDirection.Normalize();
                gameObject.GetComponent<Rigidbody2D>().velocity = moveDirection * currentSpeed;
                brisingrRB2D.position = new Vector3(brisingrRB2D.position.x + currentSpeed, brisingrRB2D.position.y, 0);
            }
            else
            {
                rightMovement = false;
            }
        }
    }



    IEnumerator Attack(float BulletshootingCD)
    {
        Instantiate(brisingrBullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(BulletshootingCD);
        Shoot();
    }

    void Shoot()
    {
        float BulletshootingCD = 0.4f;
        float shootingTime = 0.3f;
        float shootingCD = 4.0f;
        if (startBossFight1)
        {
            if (startShooting == true)
            {
                if (shooting == true)
                {
                    SoundManager.instance.PlaySingle(proyectil);
                    StartCoroutine(Attack(BulletshootingCD));
                    shooting = false;
                    Invoke("ShootingTime", shootingTime);
                    numBullets++;
                }
            }
        }

        startShooting = false;
        Invoke("ShootingCD", shootingCD);

    }

    void isChangeFase()
    {
        changeFase = true;
    }

    void ShootingCD()
    {
        startShooting = true;
    }

    void ShootingTime()
    {
        shooting = true;
    }

}
