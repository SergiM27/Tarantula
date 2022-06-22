using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStarter : MonoBehaviour {

    public AudioClip bossTheme;
    public AudioClip close;
    public AudioClip roar;

    private GameObject ShowHealth;
    private GameObject bossWall;

    private float zoomOut=9.0f;
    private float zoomSpeed = 1.5f;
    private float destrTime = 5.0f;

    private Vector3 newPosition;

    private void Awake()
    {
        ShowHealth = GameObject.Find("BrisingrHealthBar");
        ShowHealth.gameObject.SetActive(false);
    }
    private void Start()
    {
        newPosition = new Vector3(-2.66f, -15, 0f);
        bossWall = GameObject.Find("BossWall");
        bossWall.gameObject.SetActive(false);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (GameManager.brisingrHealth > 0)
            {
                this.gameObject.transform.position = newPosition;
                SoundManager.instance.PlaySingle(close);
                ShowHealth.gameObject.SetActive(true);
                bossWall.gameObject.SetActive(true);
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoomOut, Time.deltaTime*zoomSpeed);
                SoundManager.instance.PlaySingle2(roar);
                SoundManager.instance.musicSource.Stop();
                SoundManager.instance.MusicPlayer(bossTheme);
                Brisingr.startBossFight1 = true;
                Invoke("DestroyTrigger", destrTime);
            }
        }
    }

    void DestroyTrigger()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if(Brisingr.startBossFight1==true)
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoomOut, Time.deltaTime * zoomSpeed);
    }
}
