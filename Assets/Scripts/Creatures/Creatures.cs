using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Creatures : MonoBehaviour
{
    //Navigation
    private Vector3 destination; //the current position the creature is moving towards
    private Vector3 previousNode; //the previously visited node, the one the creature is moving away from
    protected NavMeshAgent creature; 

    private List<Vector3> nodes; //Stores the positions of the nodes that can be visited

    //Interaction 
    public int damage;

    protected void Start()
    {
        creature = GetComponent<NavMeshAgent>();
        nodes = new List<Vector3>(NodesScript.notVisitedNodes);         //initializing the nodes list 
        previousNode = transform.position;                              //setting the previousNode to be the creatures current position 
        destination = FindingFirstClosestNode(transform.position);      //finding the node that is closest to the creature and setting it to be the destination
    }

    public virtual Vector3 FindingFirstClosestNode(Vector3 currPos) //This method is used to find the closest node
    {
        float bestDistance = float.MaxValue; //storing the maximal float value as the best destination
        Vector3 closestNode = Vector3.zero; 

        foreach (Vector3 nodePosition in nodes) //For each node, calculating the distance between the creatures current position and the node position.
        {
            float distance = Vector3.Distance(currPos, nodePosition); 
            if (distance < bestDistance) //if the current node is closer than the previously found node, update the best distance and closest node.
            {
                bestDistance = distance;
                closestNode = nodePosition;
            }
        }
        return closestNode; //returning the position of the closest node
    }

    public virtual void Patrol()
    {
        MoveTowards(destination); 
        if (Vector3.Distance(transform.position, destination) < 3) //if the creature have reached the destination, the node gets removed from the nodes list
        {                                                          //then finding the closest node to the one previously visited and setting it as the destination 
            nodes.Remove(destination);
            Vector3 oldPosition = destination;
            destination = FindingFirstClosestNode(previousNode);
            previousNode = oldPosition;         // setting the previous node to old position (to find closest node to it later)
        }
    }
    public void MoveTowards(Vector3 position) //Using the NavMesh to move the creature to the specified position
    {
        creature.SetDestination(position);
    }

    protected virtual void OnCollisionEnter(Collision collision) //Makiing damage upon collision
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            playerScript.TakeDamage(damage);
        }
    }
}
