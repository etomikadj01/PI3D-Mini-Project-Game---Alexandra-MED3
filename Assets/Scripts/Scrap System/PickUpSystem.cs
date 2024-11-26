using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.PackageManager;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform itemSlot;
    public Inventory inventory;
    public static int objectIndex = 0;

    private void Start()
    {
        PlayerScript.interactionEvent.AddListener(HandlePickup); 
    }

    void Update()
    {
        SwitchItem();
        if (Input.GetKeyDown(KeyCode.G) && objectIndex % 4 < inventory.items.Count)
        {
            IPickableItem itemToDrop = inventory.items[objectIndex % 4];
            if (itemToDrop != null)
            {
                Transform itemToDropTransfrom = (itemToDrop as MonoBehaviour)?.transform;
                DropItem(itemToDrop, itemToDropTransfrom);
            }
        }
    }

    public void HandlePickup(Collider pickupable)
    {
        var item = pickupable.GetComponent<IPickableItem>();
        if (item != null)
        {
            PickupItem(item, pickupable.transform);
        }
    }
    private void PickupItem(IPickableItem item, Transform itemTransform)
    {
        if (inventory.AddItem(item))
        {
            objectIndex = inventory.items.Count - 1;
            itemTransform.SetParent(playerCamera.transform);
            itemTransform.position = itemSlot.position;
        }
    }

    private void DropItem(IPickableItem item, Transform itemTransform)
    {
        if (inventory.RemoveItem(item))
        {
            itemTransform.SetParent(null);
        }
    }

    public void SwitchItem() //Switching item with the mouse wheel 
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            objectIndex++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            objectIndex--;
        }

        if (objectIndex < 0)
        {
            objectIndex = 3;
        }
    }
}