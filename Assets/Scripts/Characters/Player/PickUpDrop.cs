using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrop : MonoBehaviour
{
    private GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    private float timerNull = 1.0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Drop"))
        {
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
            if (currentInterObjScript != null)
            {
                if (currentInterObjScript.inventory == true)
                {
                    inventory.AddItem(currentInterObj);
                }
                else
                {
                    currentInterObj.SendMessage("DoInteraction");
                }
            }
            Invoke("CurrentNull", timerNull);
           
        }
    }

    void CurrentNull()
    {
        currentInterObj = null;
    }

    
}
