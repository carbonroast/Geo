using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint next_waypoint;

    private void OnDrawGizmos()
    {
        if(next_waypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, next_waypoint.transform.position);
        }
        
    }
}
