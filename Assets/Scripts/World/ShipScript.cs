using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public int totalShipScrap = 0;
    public GameObject[] scrapOnMap;
    public int scrapOnMapCost = 0;
    void Start()
    {
        scrapOnMap = GameObject.FindGameObjectsWithTag("Scrap");
        foreach (GameObject go in scrapOnMap) 
        {
           int itemCost = go.GetComponent<IPickableItem>().ScrapValue;
           scrapOnMapCost += itemCost;
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scrap"))
        {
            totalShipScrap += other.GetComponent<IPickableItem>().ScrapValue;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Scrap"))
        {
            totalShipScrap -= other.GetComponent<IPickableItem>().ScrapValue;
        }
    }
}
