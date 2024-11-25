using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    public GameObject deathScreenUI;
    private float range = 20f;
    public int health = 100;

    public static UnityEvent<Collider> interactionEvent = new();
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            PlayerDeathScreen();
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

    public void PlayerDeathScreen() 
    {
        deathScreenUI.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.None; 
        UnityEngine.Cursor.visible = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked; 
        UnityEngine.Cursor.visible = false;
    }
}
