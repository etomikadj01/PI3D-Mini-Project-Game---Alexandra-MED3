using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NodesScript : MonoBehaviour
{
    public static List<Vector3> notVisitedNodes { get; private set; } = new(); //A list that will store positions of the nodes.

    private void Awake() 
    {
        //Finding all of the nodes on the map and storing them in the array. Then looping through them and storring their position in a list.
        GameObject[] nodesArray = GameObject.FindGameObjectsWithTag("Node"); 
        foreach (GameObject node in nodesArray)
        {
            notVisitedNodes.Add(node.transform.position);
        }
    }
}
