using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    private float range = 20f;
    public int health = 100;

    public static UnityEvent<Collider> interactionEvent = new();
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("U dead");
        }
    }

    public void Update()
    {
        Interactions();
    }

    public RaycastHit Interactions()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, range))
        {
            Collider colliderHit = hit.collider;
            interactionEvent?.Invoke(colliderHit);
            return hit;
        }
        return new RaycastHit();
    }
}
