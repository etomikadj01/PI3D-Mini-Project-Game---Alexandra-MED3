using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorOutdoorManager : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject player;
    private float range = 20f;


    void Update()
    {
        StartShip();
    }

    private void StartShip()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            if (hit.collider.CompareTag("Button") && Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = new Vector3(0, 0, 0);
            }
        }
    }

}
