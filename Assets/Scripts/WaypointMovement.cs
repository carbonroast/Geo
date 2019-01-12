using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    public Waypoint current_waypoint;
    public float movement_speed = 5.0f;
    public float rotation_speed = 45.0f;



    public void MoveToNextWaypoint()
    {
        current_waypoint = current_waypoint.next_waypoint;
        StartCoroutine(RotateToWP(true));
    }

    IEnumerator RotateToWP(bool initial_rotation)
    {
        Quaternion _goal_rotation;
        if (initial_rotation)
        {
            _goal_rotation = Quaternion.LookRotation(current_waypoint.transform.position - transform.position);
        }
        else
        {
            _goal_rotation = current_waypoint.transform.rotation;
        }

        while (true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _goal_rotation, rotation_speed * Time.deltaTime);
            if (transform.rotation != _goal_rotation)
            {
                yield return null;
            }
            else
            {
                break;
            }
        }

        if (initial_rotation)
        {
            StartCoroutine(MoveToWP());
        }
    }

    IEnumerator MoveToWP()
    {
        while (true)
        {
            transform.position += transform.forward *movement_speed* Time.deltaTime;

            if (Vector3.Dot(transform.forward, current_waypoint.transform.position - transform.position) <= 0)
            {
                transform.position = current_waypoint.transform.position;
                break;
            }
            yield return null;

        }
        StartCoroutine(RotateToWP(false));
    }
}
