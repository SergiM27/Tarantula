using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [Space]
    [Header("Character attributes:")]
    public static float movementWalkSpeed = 3.0f;
    public static float movementRunSpeed = 6.5f;

    [Space]
    [Header("Cooldowns")]

    protected float BulletshootingCD;
    public static float shootingCDNormal = 0.25f;
    public static float shootingCDSlime = 0.5f;
    public static float shootingCDElectric = 0.18f;
    public static float shootingCDIce = 0.4f;
    public static float shootingCDFire = 0.25f;

    [Space]
    [Header("Dash:")]
    private GameObject dashBar1;
    private GameObject dashBar2;
    private GameObject dashBar3;
    public Sprite dashEmpty;
    public Sprite dashFull;
    public AudioClip dash;
    private bool isDashUsed = false;
    private float dashReUseCD = 0.5f;
    private float dashCDBeggining = 4.0f;
    private float dashCD = 3.0f;
    const float DASH_DISTANCE = 1800f;
    private int dashNum = 3;
    private int maxDashNum = 3;

    [Space]
    [Header("Character statistics:")]
    private Vector2 movementDirection;
    private Vector2 aimDirection;
    protected float movementSpeed;
    protected float movementSpeedMin = 0.0f;
    protected float movementSpeedMax = 1.0f;

    [Space]
    [Header("Shooting:")]
    protected bool shooting = true;

    [Space]
    [Header("Bullets:")]
    public GameObject bullet_Normal;
    public GameObject bullet_Slime;
    public GameObject bullet_Electricity;
    public GameObject bullet_Ice;
    public GameObject bullet_Fire;


    [Space]
    [Header("Others:")]

    [Space]
    [Header("References:")]
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject crosshair;

    private void Awake()
    {
        shootingCDNormal = 0.25f;
        shootingCDSlime = 0.5f;
        shootingCDElectric = 0.18f;
        shootingCDIce = 0.4f;
        shootingCDFire = 0.25f;
        movementWalkSpeed = 3.0f;
        movementRunSpeed = 6.5f;
    }

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponentInChildren<Animator>();
        dashBar1 = GameObject.Find("DashBar1");
        dashBar2 = GameObject.Find("DashBar2");
        dashBar3 = GameObject.Find("DashBar3");
        crosshair = GameObject.Find("Crosshair");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        AimAndShoot();
        ProcessInputs();
        Animate();
        HandleDash();

    }
    private void FixedUpdate()
    {
        Move();
        Dash();
    }

    public void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        aimDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, movementSpeedMin, movementSpeedMax);
        movementDirection.Normalize();
    }

    void HandleDash()
    {
        if (dashNum < maxDashNum)
        {
            dashCD += Time.deltaTime;
        }
        else
        {
            dashCD =0;
        }

        if (dashCD >= dashCDBeggining)
        {
            if (dashNum < maxDashNum)
            {
                dashNum++;
                dashCD = 0;
            }
            
        }
        DashSprite();
    }

    void Dash()
    {
        if (Input.GetAxis("A Button") >0)
        {
            if (movementDirection != Vector2.zero)
            {
                if (isDashUsed == false)
                {
                    if (dashNum > 0)
                    {
                        SoundManager.instance.RandomizeSfx(dash);
                        rb.velocity = (movementDirection * movementSpeed) * movementWalkSpeed * DASH_DISTANCE * Time.deltaTime;
                        isDashUsed = true;
                        dashNum--;
                        Invoke("DashAvailable", dashReUseCD);
                    }

                }

            }

        }
    }

    void DashSprite()
    {
        if (dashBar1 != null)
        {
            switch (dashNum)
            {

                case 0:
                    dashBar1.gameObject.GetComponent<Image>().sprite = dashEmpty;
                    dashBar2.gameObject.GetComponent<Image>().sprite = dashEmpty;
                    dashBar3.gameObject.GetComponent<Image>().sprite = dashEmpty;
                    break;
                case 1:
                    dashBar1.gameObject.GetComponent<Image>().sprite = dashFull;
                    dashBar2.gameObject.GetComponent<Image>().sprite = dashEmpty;
                    dashBar3.gameObject.GetComponent<Image>().sprite = dashEmpty;
                    break;
                case 2:
                    dashBar1.gameObject.GetComponent<Image>().sprite = dashFull;
                    dashBar2.gameObject.GetComponent<Image>().sprite = dashFull;
                    dashBar3.gameObject.GetComponent<Image>().sprite = dashEmpty;
                    break;
                case 3:
                    dashBar1.gameObject.GetComponent<Image>().sprite = dashFull;
                    dashBar2.gameObject.GetComponent<Image>().sprite = dashFull;
                    dashBar3.gameObject.GetComponent<Image>().sprite = dashFull;
                    break;
            }
        }
    }

    void Move()
    {
        if (PauseMenu.gameIsPaused == false)
        {
            float run = Input.GetAxis("L2");
            this.gameObject.GetComponent<AudioSource>().enabled = true;
            if (run != 0)
            {
                this.gameObject.GetComponent<AudioSource>().pitch = 1.2f;
                rb.velocity = (movementDirection * movementSpeed) * movementRunSpeed;

            }
            else
            {
                this.gameObject.GetComponent<AudioSource>().pitch = 0.8f;
                rb.velocity = (movementDirection * movementSpeed) * movementWalkSpeed;
            }
        }

    }


    void Animate()
    {
        if (PauseMenu.gameIsPaused == false)
        {
            if (movementDirection != Vector2.zero)
            {

                animator.SetFloat("Horizontal", movementDirection.x);
                animator.SetFloat("Vertical", movementDirection.y);
            }
            else
            {
                this.gameObject.GetComponent<AudioSource>().enabled = false;
            }
            if (aimDirection != Vector2.zero)
            {
                animator.SetFloat("Horizontal", aimDirection.x);
                animator.SetFloat("Vertical", aimDirection.y);

            }
            animator.SetFloat("Speed", movementSpeed);
        }


    }

    void DashAvailable()
    {
        isDashUsed = false;
    }

    public void AimAndShoot()
    {

        Vector3 aim = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        float shoot = Input.GetAxis("Shoot");


        if (aim.magnitude > 0.0f)
        {

            crosshair.gameObject.SetActive(true);
            crosshair.transform.localPosition = aim;
            if (shoot != 0)
            {
                if (shooting == true)
                {

                    if (GameManager.slimeUnlocked == false)
                    {
                        switch (GameManager.bulletType)
                        {
                            case 1:
                                Instantiate(bullet_Normal, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDNormal;
                                break;
                        }
                    }
                    if (GameManager.slimeUnlocked == true && GameManager.electricUnlocked == false)
                    {
                        switch (GameManager.bulletType)
                        {
                            case 1:
                                Instantiate(bullet_Normal, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDNormal;
                                break;
                            case 2:
                                Instantiate(bullet_Slime, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDSlime;
                                break;
                        }
                    }
                    if (GameManager.electricUnlocked == true && GameManager.iceUnlocked == false)
                    {
                        switch (GameManager.bulletType)
                        {
                            case 1:
                                Instantiate(bullet_Normal, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDNormal;
                                break;
                            case 2:
                                Instantiate(bullet_Slime, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDSlime;
                                break;
                            case 3:
                                Instantiate(bullet_Electricity, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDElectric;
                                break;
                        }
                    }
                    if (GameManager.iceUnlocked == true && GameManager.fireUnlocked == false)
                    {
                        switch (GameManager.bulletType)
                        {
                            case 1:
                                Instantiate(bullet_Normal, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDNormal;
                                break;
                            case 2:
                                Instantiate(bullet_Slime, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDSlime;
                                break;
                            case 3:
                                Instantiate(bullet_Electricity, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDElectric;
                                break;
                            case 4:
                                Instantiate(bullet_Ice, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDIce;
                                break;

                        }
                    }
                    if (GameManager.fireUnlocked == true)
                    {
                        switch (GameManager.bulletType)
                        {
                            case 1:
                                Instantiate(bullet_Fire, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDFire;
                                break;
                            case 2:
                                Instantiate(bullet_Slime, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDSlime;
                                break;
                            case 3:
                                Instantiate(bullet_Electricity, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDElectric;
                                break;
                            case 4:
                                Instantiate(bullet_Ice, transform.position, Quaternion.identity);
                                BulletshootingCD = shootingCDIce;
                                break;
                        }
                    }
                    shooting = false;
                    Invoke("ShootingCD", BulletshootingCD);
                }
               
            }



        }
        else
        {
            crosshair.transform.localPosition = new Vector3(0, 0, 0);
            crosshair.gameObject.SetActive(false);
        }

    }
    void ShootingCD()
    {
        shooting = true;
    }
}