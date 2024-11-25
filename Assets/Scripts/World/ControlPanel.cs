using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] GameObject performanceReport;
    public ShipScript shipScript;

    public TMP_Text totalObjectCost;
    public TMP_Text shipObjectCost;
    public TMP_Text grade;

    private void Start()
    {
        PlayerScript.interactionEvent.AddListener(StartShip);
    }

    private void StartShip(Collider button)
    {
        if (button.CompareTag("Button"))
        {
            performanceReport.SetActive(true);
            totalObjectCost.SetText(shipScript.totalShipScrap.ToString());
            shipObjectCost.SetText(shipScript.scrapOnMapCost.ToString());
            grade.SetText("X");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


}
