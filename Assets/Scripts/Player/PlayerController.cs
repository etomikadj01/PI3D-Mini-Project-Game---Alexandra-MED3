using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementSmoothing = 0.1f;

    Vector3 moveDirection;
    private Vector3 currentVelocity;
    Rigidbody rb;

    float horizontalMovement;
    float verticalMovement;
    

    void Start()
    {
       rb = GetComponent<Rigidbody>();
       rb.freezeRotation = true;
    }

    private void Update()
    {
        MovementInput();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void MovementInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    private void PlayerMovement()
    {
        Vector3 playerVelocity = moveDirection.normalized * movementSpeed;

        rb.velocity = Vector3.SmoothDamp(rb.velocity, playerVelocity, ref currentVelocity, movementSmoothing);
    }
}
