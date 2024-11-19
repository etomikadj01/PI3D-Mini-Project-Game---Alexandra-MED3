using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teeth : MonoBehaviour, PickableItem
{
    int scrapValue = 0;
    protected int min = 60;
    protected int max = 84;
    private void Awake()
    {
        scrapValue = Random.Range(min, max);
    }

    public int ScrapValue { get { return scrapValue; } set { scrapValue = value; } }
    public string Name
    {
        get
        {
            return "Teeth";
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
        transform.rotation = Quaternion.Euler(0, -90, 0);
        //start animator
    }
}
