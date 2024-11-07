using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform itemSlot;
    private float range = 20f;
   
    void Update()
    {
        SelectPickupableObject();
    }

    public void SelectPickupableObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            if (hit.collider.CompareTag("Scrap") && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("This is scrap");
                hit.transform.SetParent(Camera.main.transform);
                hit.transform.position = itemSlot.position;
            }
        }
    }
}
