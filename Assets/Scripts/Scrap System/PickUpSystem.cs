using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.PackageManager;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform itemSlot;
    private float range = 20f;
    public Inventory inventory;
    public static int objectIndex = 0;

    void Update()
    {
        DetectAndHandlePickup();  // ground chechk and remove the rigidbody 
        SwitchItem();

        if (Input.GetKeyDown(KeyCode.G) && objectIndex % 4 < inventory.items.Count)
        {
            PickableItem itemToDrop = inventory.items[objectIndex % 4];
            if (itemToDrop != null)
            {
                Transform itemToDropTransfrom = (itemToDrop as MonoBehaviour)?.transform;
                DropItem(itemToDrop, itemToDropTransfrom);
            }

        }
    }

    public void DetectAndHandlePickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            var item = hit.collider.GetComponent<PickableItem>();
            if (item != null && Input.GetKeyDown(KeyCode.E))
            {
                PickupItem(item, hit.transform);
            }
        }
    }
    private void PickupItem(PickableItem item, Transform itemTransform)
    {
        if (inventory.AddItem(item))
        {
            objectIndex = inventory.items.Count - 1;
            itemTransform.SetParent(playerCamera.transform);
            itemTransform.position = itemSlot.position;
        }
    }

    private void DropItem(PickableItem item, Transform itemTransform)
    {
        if (inventory.RemoveItem(item))
        {
            //itemTransform.rotation = Quaternion.identity;
            itemTransform.SetParent(null);
        }
    }

    public void SwitchItem()
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

        //if (objectIndex%4 <= inventory.items.Count - 1)
        //{
            //print(objectIndex);
            //print((inventory.items[objectIndex%4] as MonoBehaviour)?.transform.position);
        //}
        
        //Switching item, so that when i use the mouse wheel the index changes
        //Mouse scrolling detection: Input.GetAxis("Mouse ScrollWheel"), specify that if (Input.GetAxis("Mouse ScrollWheel") > 0f) {selectedObject ++} and vise versa if opposite
    }
}