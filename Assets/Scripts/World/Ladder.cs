using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Ladder : MonoBehaviour
{
  
    [SerializeField] GameObject player;
    void Start()
    {
        PlayerScript.interactionEvent.AddListener(LadderClimb);
    }


    private void LadderClimb(Collider ladder)
    {
        if (ladder.CompareTag("Ladder"))
        {
            player.transform.position = new Vector3(-75.8f, 4.45f, -62.5f);
        }
    }
}
