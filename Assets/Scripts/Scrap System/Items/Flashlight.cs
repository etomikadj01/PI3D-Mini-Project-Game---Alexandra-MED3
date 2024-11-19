using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour, PickableItem
{
    private int scrapValue = 0;
    public int ScrapValue { get { return scrapValue; } set { scrapValue = value; } }
    public string Name
    {
        get
        {
            return "Flashlighr";
        }
    }

    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }
    public void OnPickup()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        //start animator
    }  
}
