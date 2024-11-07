using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCameraController : MonoBehaviour
{
    [SerializeField] float sensetivity = 100f;
    [SerializeField] Transform playerBody;

    float pitch = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float moveH = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;
        float moveV = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;

        pitch -= moveH;
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        playerBody.Rotate(Vector3.up * moveV);
    }
}
