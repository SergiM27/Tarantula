using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coins : MonoBehaviour {


    private void LateUpdate()
    {
        this.gameObject.GetComponent<Text>().text = GameManager.numCoins.ToString();
    }
}
