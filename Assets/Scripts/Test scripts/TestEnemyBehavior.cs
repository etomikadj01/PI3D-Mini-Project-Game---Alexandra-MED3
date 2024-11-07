using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] float speed;

    Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    //fixed update
    void Update()
    {
        if (objectRenderer.isVisible)
        {
            Debug.Log("Object is visible");
        }
        else
        {
            Debug.Log("Object is no longer visible");
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}