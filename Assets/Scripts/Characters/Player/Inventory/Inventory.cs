using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{

    public GameObject[] inventory = new GameObject[6];
    private Button[] inventoryButtons = new Button[6];
    public Sprite[] inventorySprites = new Sprite[4];
    private Vector3 storePosition= new Vector3(200, 200, 0);

    private void Awake()
    {
        inventoryButtons[0] = GameObject.Find("Slot 0").GetComponent<Button>();
        inventoryButtons[1] = GameObject.Find("Slot 1").GetComponent<Button>();
        inventoryButtons[2] = GameObject.Find("Slot 2").GetComponent<Button>();
        inventoryButtons[3] = GameObject.Find("Slot 3").GetComponent<Button>();
        inventoryButtons[4] = GameObject.Find("Slot 4").GetComponent<Button>();
        inventoryButtons[5] = GameObject.Find("Slot 5").GetComponent<Button>();
        inventory[0] = null;
        inventory[1] = null;
        inventory[2] = null;
        inventory[3] = null;
        inventory[4] = null;
        inventory[5] = null;
        RemoveItem0();
        RemoveItem1();
        RemoveItem2();
        RemoveItem3();
        RemoveItem4();
        RemoveItem5();
    }


    public void AddItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                PutImageInInventory(item, i);
                item.gameObject.transform.position= storePosition;
                break;
            }
        }

    }

    void PutImageInInventory(GameObject item, int i)
    {
        switch (item.name)
        {
            case "Skull":
                inventoryButtons[i].image.overrideSprite = inventorySprites[0];
                break;
            case "HealthPot":
                inventoryButtons[i].image.overrideSprite = inventorySprites[1];
                break;
            case "Star":
                inventoryButtons[i].image.overrideSprite = inventorySprites[2];
                break;
            case "Boot":
                inventoryButtons[i].image.overrideSprite = inventorySprites[3];
                break;
        }
    }
    void EmptyImageInInventory(int i)
    {
        inventoryButtons[i].image.overrideSprite = inventorySprites[4];
    }


    public void RemoveItem0()
    {

        if (inventory[0] != null)
        {
            inventory[0].gameObject.GetComponent<InteractionObject>().DoInteraction();
            EmptyImageInInventory(0);
            inventory[0] = null;
        }
    }
    public void RemoveItem1()
    {

        if (inventory[1] != null)
        {
            inventory[1].gameObject.GetComponent<InteractionObject>().DoInteraction();
            inventory[1] = null;
            EmptyImageInInventory(1);
        }
    }
    public void RemoveItem2()
    {

        if (inventory[2] != null)
        {
            inventory[2].gameObject.GetComponent<InteractionObject>().DoInteraction();
            inventory[2] = null;
            EmptyImageInInventory(2);
        }
    }
    public void RemoveItem3()
    {

        if (inventory[3] != null)
        {
            inventory[3].gameObject.GetComponent<InteractionObject>().DoInteraction();
            inventory[3] = null;
            EmptyImageInInventory(3);
        }
    }
    public void RemoveItem4()
    {

        if (inventory[4] != null)
        {
            inventory[4].gameObject.GetComponent<InteractionObject>().DoInteraction();
            inventory[4] = null;
            EmptyImageInInventory(4);
        }
    }
    public void RemoveItem5()
    {

        if (inventory[5] != null)
        {
            inventory[5].gameObject.GetComponent<InteractionObject>().DoInteraction();
            inventory[5] = null;
            EmptyImageInInventory(5);
        }
    }

    public void EmptyInventoryBetweenScenes()
    {
        EmptyImageInInventory(0);
        EmptyImageInInventory(1);
        EmptyImageInInventory(2);
        EmptyImageInInventory(3);
        EmptyImageInInventory(4);
        EmptyImageInInventory(5);
        inventory[0] = null;
        inventory[1] = null;
        inventory[2] = null;
        inventory[3] = null;
        inventory[4] = null;
        inventory[5] = null;
    }
   

}
