using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilHeadScript : Creatures
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    private bool inRange = false;
    private bool playerFound = false;

    [SerializeField] Renderer objectRenderer;
    [SerializeField] LayerMask layerMask;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private new void Start()
    {
        base.Start();
        objectRenderer = GetComponent<Renderer>();

        damage = 90;
    }

    //Used to check whether the player is inside the detection sphere
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    public void CheckIfVisible()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        bool haveHit = Physics.Raycast(transform.position, direction, out RaycastHit hitinfo, 200f, layerMask); //check if layermask is used
    
        if (!objectRenderer.isVisible) //If this is not visible, move towards player                                                                                           
        {
            creature.isStopped = false;
        }
        else if (haveHit && !hitinfo.collider.CompareTag("Player")) //Else if it hit something and it is not the player, we can move. We do that to check whether there is an obstruction between us
        {
            creature.isStopped = false;
        }
        else //if the player is looking and we hit them than mark that we found them
        {
            playerFound = true;
            creature.isStopped = true;
            creature.velocity = Vector3.zero;
        }
    }

    private void CoilHeadSpeed()
    {
        if (playerFound && inRange)
        {
            creature.speed = 17f;
            creature.acceleration = 17f;
        }
        else
        {
            creature.speed = 2f;
            creature.acceleration = 2f;
        }
    }
    private void ChasePlayer()
    {      
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        if (playerScript.health > 0 && inRange)
        {
            MoveTowards(player.transform.position);
        }     
    }

    private void FixedUpdate()
    {
        CheckIfVisible();

        if (inRange && playerFound)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }

        CoilHeadSpeed();
    }
}
