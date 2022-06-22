using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public GameObject pickUpParticles;
    private GameObject particles;
    public GameObject shield;
    private GameObject player;
    public static bool shieldOn=false;
    public bool inventory;
    public string itemType;

    public AudioClip healthSound;
    public AudioClip coinSound;
    public AudioClip starSound;
    public AudioClip potionSound;
    public AudioClip skullSound;
    public AudioClip bootSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void DoInteraction()
    {
        StartCoroutine(UseItem());
    }

    public IEnumerator UseItem()
    {

        particles = pickUpParticles;
        switch (gameObject.name)
        {
            case "Skull":
                SoundManager.instance.PlaySingle2(skullSound);
                float Skullduration = 6.0f;
                SkullIn();
                yield return new WaitForSeconds(Skullduration);
                SkullOut();
                break;
            case "Star":
                SoundManager.instance.PlaySingle(starSound);
                float shieldDuration = 6.0f;
                GameObject particlesShield = Instantiate(shield, player.transform.position, this.transform.rotation);
                particlesShield.transform.SetParent(player.transform);
                shieldOn = true;
                yield return new WaitForSeconds(shieldDuration);
                shieldOn = false;
                Destroy(particlesShield);
                break;
            case "Boot":
                SoundManager.instance.PlaySingle(bootSound);
                float bootDuration = 4.0f;
                BootIn();
                yield return new WaitForSeconds(bootDuration);
                BootOut();
                break;
            case "HealthPot":
                SoundManager.instance.PlaySingle(potionSound);
                if (GameManager.playerHealth < 6)
                {
                    
                    GameManager.playerHealth=GameManager.playerHealth +2;
                }
                break;
            case "Coin":
                SoundManager.instance.PlaySingle(coinSound);
                GameManager.numCoins++;
                break;
            case "Heart":
                if (GameManager.playerHealth < 6)
                {
                    SoundManager.instance.PlaySingle(healthSound);
                    GameManager.playerHealth++;
                }
                break;
        }
        Destroy(gameObject);

    }

    void BootIn()
    {
        float bWalkSpeed = 7.0f;
        float bRunSpeed = 12.0f;
        PlayerController.movementWalkSpeed = bWalkSpeed;
        PlayerController.movementRunSpeed = bRunSpeed;
        GameObject particlesInBoot = Instantiate(particles, player.transform.position, this.transform.rotation);
        particlesInBoot.transform.SetParent(player.transform);
    }


    void BootOut()
    {
        float initMovementRunSpeed = 6.5f;
        float initMovementWalkSpeed = 3.0f;
        PlayerController.movementWalkSpeed = initMovementWalkSpeed;
        PlayerController.movementRunSpeed = initMovementRunSpeed;
    }
    void SkullIn()
    {
       
        float Skulleffect = 1.5f;
        PlayerController.shootingCDNormal = PlayerController.shootingCDNormal / Skulleffect;
        PlayerController.shootingCDSlime = PlayerController.shootingCDSlime / Skulleffect;
        PlayerController.shootingCDElectric = PlayerController.shootingCDElectric / Skulleffect;
        PlayerController.shootingCDIce = PlayerController.shootingCDIce / Skulleffect;
        PlayerController.shootingCDFire = PlayerController.shootingCDFire / Skulleffect;
        GameObject particlesInSkull = Instantiate(particles, player.transform.position, this.transform.rotation);
        particlesInSkull.transform.SetParent(player.transform);
    }
    void SkullOut()
    {
        float Skulleffect = 1.5f;
        PlayerController.shootingCDNormal = PlayerController.shootingCDNormal * Skulleffect;
        PlayerController.shootingCDSlime = PlayerController.shootingCDSlime * Skulleffect;
        PlayerController.shootingCDElectric = PlayerController.shootingCDElectric * Skulleffect;
        PlayerController.shootingCDIce = PlayerController.shootingCDIce * Skulleffect;
        PlayerController.shootingCDFire = PlayerController.shootingCDFire * Skulleffect;
    }
}
