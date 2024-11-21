using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private const int SLOTS = 4;
    public List<PickableItem> items = new List<PickableItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public bool AddItem(PickableItem item)
    {
        if (items.Count >= SLOTS)
            return false;

        Collider collider = (item as MonoBehaviour)?.GetComponent<Collider>(); 
        if (collider != null && collider.enabled)
        {
            Rigidbody rb = (item as MonoBehaviour)?.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePosition | rb.constraints;

            collider.isTrigger = true;
            items.Add(item); 
            item.OnPickup();
            ItemAdded?.Invoke(this, new InventoryEventArgs(item));
            return true;
        }
        return false;
    }

    public bool RemoveItem(PickableItem item)
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

