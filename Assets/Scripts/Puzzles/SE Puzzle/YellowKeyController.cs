using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowKeyController : MonoBehaviour {

    public static bool firstSwitch = false;
    public static bool secondSwitch = false;
    private GameObject yellowKey;



    void Start ()
    {
        yellowKey = GameObject.Find("YellowKey");
        yellowKey.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
       if(GameManager.puzzle4 == false)
       {
            if (firstSwitch && secondSwitch)
            {
                yellowKey.gameObject.SetActive(true);
                GameManager.puzzle4 = true;
            }
          
       }
        
	}
}
