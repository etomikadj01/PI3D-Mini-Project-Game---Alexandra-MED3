using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryHandler : MonoBehaviour 
{
    //Listens for items being added to the inventory and updates the UI 

    public Inventory Inventory;
    void Start()
    {
        //Subscribes to the ItemAdded event and the ItemRemoved event from the Inventory class
        Inventory.ItemAdded += InventoryScript_ItemAdded; 
        Inventory.ItemRemoved += InventoryScript_ItemRemoved;
    }

    private void Update()
    {
        UpdatingSelectedItemUI();
    }
    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e) //When an item is added, this get's triggered. Adding the new item to a slot in the UI-inventory panel
    {
        Transform inventoryPanel = transform.Find("InventoryPanel"); //finds the inventory panel
        foreach (Transform slot in inventoryPanel)  //for each slot in the inventory pannel, finds an image and get's it's sprite component, enables it
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            if (!image.enabled)
            { 
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }
 
    private void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e) //When an item is removed, this get's triggered.
    {
        Transform inventoryPanel = transform.Find("InventoryPanel"); //finds the inventory panel
        foreach (Transform slot in inventoryPanel)  //for each slot in the inventory pannel, finds an image and get's it's sprite component, disables it and empties the inventory slot(UI)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            if (image.enabled && image.sprite == e.Item.Image)
            {
                image.enabled = false;
                image.sprite = null;

                break;
            }
        }
    }

    private void UpdatingSelectedItemUI() //Changing the size of the slot based on whether the item is selected
    {
        int index = PickUpSystem.objectIndex;
        Transform inventoryPanel = transform.Find("InventoryPanel");
        float scale1 = 1f;
        float scale2 = 1.2f;
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            Transform panel = inventoryPanel.GetChild(i);
            if (i == index % 4)
            {
                panel.transform.localScale = new Vector3(scale2, scale2, scale2);
                
            }
            else
            {
                panel.transform.localScale = new Vector3(scale1, scale1, scale1);
            }
        }

    }
}
