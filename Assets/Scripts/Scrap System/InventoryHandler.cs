using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryHandler : MonoBehaviour //listens for items being added to the inventory and updates the UI 
{
    public Inventory Inventory;
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded; //Subscribes to the ItemAdded event from the inventory class 
        Inventory.ItemRemoved += InventoryScript_ItemRemoved;
    }

    private void Update()
    {
        UpdatingSelectedItemUI();
    }
    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e) //When an item
    {
        Transform inventoryPanel = transform.Find("InventoryPanel"); //finds the inventory panel
        foreach (Transform slot in inventoryPanel)  //for each slot in the inventory pannel, finds an image and get's it's sprite component 
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
 
    private void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel"); //finds the inventory panel
        foreach (Transform slot in inventoryPanel)  //for each slot in the inventory pannel, finds an image and get's it's sprite component 
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

    private void UpdatingSelectedItemUI()
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
