using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recommendation : MonoBehaviour {


    private float transitionTime=4.0f;
	// Use this for initialization
	void Start () {

        Invoke("ChangeTransition", transitionTime);
	}
	
	// Update is called once per frame

    void ChangeTransition()
    {
        this.gameObject.GetComponent<Animator>().SetInteger("Transition", 2);
        Invoke("ChangeScene", transitionTime);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
