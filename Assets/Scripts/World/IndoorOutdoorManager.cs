using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorOutdoorManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Start()
    {
        PlayerScript.interactionEvent.AddListener(ChangeInterior);
    }

    private void ChangeInterior(Collider door)
    {
        if (door.CompareTag("DoorIn"))
        {
            player.transform.position = new Vector3(-111.5f, -31.35f, 203.5f);
        }
        else if (door.CompareTag("DoorOut"))
        {
            player.transform.position = new Vector3(-77, 4.45f, -67f);
            player.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
