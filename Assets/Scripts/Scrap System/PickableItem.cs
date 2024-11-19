using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PickableItem
{
    string Name { get; }
    Sprite Image { get; }
    void OnPickup();
    int ScrapValue { get; }
}

public class InventoryEventArgs : EventArgs //Passes information about the item when the ItemAdded event is trigered in the Inventory class
{
    public InventoryEventArgs(PickableItem item)
    {
        Item = item;
    }
    public PickableItem Item;
}


