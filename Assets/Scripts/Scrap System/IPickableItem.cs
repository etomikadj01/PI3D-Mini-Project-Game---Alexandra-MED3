using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickableItem //Interface all of the pickable items have to implement
{
    string Name { get; }
    Sprite Image { get; }
    int ScrapValue { get; }
}

public class InventoryEventArgs : EventArgs //
{
    public InventoryEventArgs(IPickableItem item)
    {
        Item = item;
    }
    public IPickableItem Item;
}


