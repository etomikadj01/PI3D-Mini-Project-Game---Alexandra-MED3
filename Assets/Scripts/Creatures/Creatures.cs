using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Creatures : MonoBehaviour
{
    //Navigation
    private Vector3 destination;
    private Vector3 previousNode;
    protected NavMeshAgent creature;
    

    //Interaction 
    public int damage;

    private List<Vector3> nodes;


    protected void Start()
    {
        creature = GetComponent<NavMeshAgent>();
        nodes = new List<Vector3>(NodesScript.notVisitedNodes);
        previousNode = transform.position;
        destination = FindingFirstClosestNode(transform.position);
    }

    public void MoveTowards(Vector3 position)
    {
        creature.SetDestination(position);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            playerScript.TakeDamage(damage);
        }
    }

    public virtual Vector3 FindingFirstClosestNode(Vector3 currPos)
    {
        float bestDistance = float.MaxValue;
        Vector3 closestNode = Vector3.zero;

        foreach (Vector3 nodePosition in nodes)
        {
            float distance = Vector3.Distance(currPos, nodePosition);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                closestNode = nodePosition;
            }
        }
        return closestNode;
    }

    public virtual void Patrol()
    {
        MoveTowards(destination);
        if (Vector3.Distance(transform.position, destination) < 10)
        {
            nodes.Remove(destination);
            Vector3 oldPosition = destination;
            destination = FindingFirstClosestNode(previousNode);
            previousNode = oldPosition;
        }
    }
}
