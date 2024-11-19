using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject performanceReport;
    private float range = 20f;
    public ShipScript shipScript;

    public TMP_Text totalObjectCost;
    public TMP_Text shipObjectCost;
    public TMP_Text grade;

    void Update()
    {
        StartShip();
    }

    private void StartShip()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            if (hit.collider.CompareTag("Button") && Input.GetKeyDown(KeyCode.E))
            {
                performanceReport.SetActive(true);
                totalObjectCost.SetText(shipScript.totalShipScrap.ToString());
                shipObjectCost.SetText(shipScript.scrapOnMapCost.ToString());
                grade.SetText("X");
            }
        }
    }

}
