using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public float spawnTimer = 10.0f;
    [SerializeField] Rigidbody creature;
    [SerializeField] Transform vent;
    [SerializeField] bool hasSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        
        if (spawnTimer <= 0 && !hasSpawned)
        {
            Instantiate(creature, vent.position, vent. rotation);
            hasSpawned = true;
        }
    }
}
