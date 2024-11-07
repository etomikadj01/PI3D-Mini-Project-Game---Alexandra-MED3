using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NodesScript : MonoBehaviour
{
    public static List<Vector3> notVisitedNodes { get; private set; } = new();

    private void Awake()
    {
        GameObject[] nodesArray = GameObject.FindGameObjectsWithTag("Node");
        foreach (GameObject node in nodesArray)
        {
            notVisitedNodes.Add(node.transform.position);
        }
    }
}
