using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSoda : MonoBehaviour, IPickableItem
{
    int scrapValue = 0;
    protected int min = 18;
    protected int max = 90;
    private void Awake()
    {
        scrapValue = Random.Range(min, max);
    }

    public int ScrapValue { get { return scrapValue; } set { scrapValue = value; } }
    public string Name
    {
        get
        {
            return "Soda";
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
