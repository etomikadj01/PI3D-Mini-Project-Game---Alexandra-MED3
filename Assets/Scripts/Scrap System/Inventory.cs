using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //

    //Creating a list that can hold objects that have the interface implemented
    private const int SLOTS = 4;
    public List<IPickableItem> items = new List<IPickableItem>();

    //Declaring two events, each respectivelly being triggered upon adding or removing an item in the methods bellow 
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public bool AddItem(IPickableItem item) //Adds the item to the list
    {
        if (items.Count >= SLOTS) //If the inventory is full then don't add the item
            return false;

        Collider collider = (item as MonoBehaviour)?.GetComponent<Collider>(); 
        if (collider != null && collider.enabled)
        {
            Rigidbody rb = (item as MonoBehaviour)?.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePosition | rb.constraints;

            collider.isTrigger = true;
            items.Add(item); 
            //item.OnPickup(); //remove
            ItemAdded?.Invoke(this, new InventoryEventArgs(item)); //Invoking the event if it has listeners, passing this
            return true;
        }
        return false;
    }

    public bool RemoveItem(IPickableItem item)
    {
        if (items.Contains(item))
        {
            Collider collider = (item as MonoBehaviour)?. GetComponent<Collider>();
            if (collider != null)
            {
                Rigidbody rb = (item as MonoBehaviour)?.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                items.Remove(item);
                collider.isTrigger = false;
                ItemRemoved?.Invoke(this, new InventoryEventArgs(item));
                return true;
            }
            return false;
        }
        return false; 
    }
}

