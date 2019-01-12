using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnNoEnemies : MonoBehaviour
{
    public WaypointMovement playerWPmovement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            playerWPmovement.MoveToNextWaypoint(); 
        }
        
    }
}
