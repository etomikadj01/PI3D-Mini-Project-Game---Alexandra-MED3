using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    private float range = 20f;
    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("U dead");
        }
    }

    //public RaycastHit Interactions()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        RaycastHit hit;
    //        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range);
    //        return hit;
    //    }
    //    return new RaycastHit();
    //}
}
