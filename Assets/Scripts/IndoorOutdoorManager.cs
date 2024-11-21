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
        if (door.CompareTag("Door"))
        {
            player.transform.position = new Vector3(0, 0, 0);
        }
    }
}
