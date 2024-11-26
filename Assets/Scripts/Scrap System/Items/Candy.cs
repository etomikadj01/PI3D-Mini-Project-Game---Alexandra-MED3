using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour, IPickableItem
{
    int scrapValue = 0;
    protected int min = 6;
    protected int max = 36;
    private void Awake()
    {
        scrapValue = Random.Range(min, max);
    }

    public int ScrapValue { get { return scrapValue; } set { scrapValue = value; } }
    public string Name
    {
        get
        {
            return "Candy";
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
}
