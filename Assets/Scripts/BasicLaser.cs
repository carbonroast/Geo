using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLaser : Laser
{

    private Vector3 facing_direction;
    private RaycastHit hit;
    private int array_counter;
    private List<Vector3> ray_positions = new List<Vector3>();
    private bool hit_wall;
    private int bounce_limit;

    public override void Start()
    {
        base.Start();
        facing_direction = transform.forward;
        array_counter = 1;
        ray_positions.Add(position);
        hit_wall = true;
        bounce_limit = 5;
        Destroy(.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        while (hit_wall && bounce_limit >= 0)
        {
            // Laser hit a bounceable layer
            if (Physics.Raycast(position, facing_direction, out hit, 5.0f, LayerMask.GetMask("Bounceable")))
            {
                // Grab all the locations the laser bounces
                ray_positions.Add(hit.point);
                facing_direction = Vector3.Reflect((hit.point - position).normalized, hit.normal);
                position = hit.point;
                array_counter += 1;
                bounce_limit -= 1;
            }
            else
            {
                hit_wall = false;
            }
        }

        array_counter += 1;
        ray_positions.Add(position + (facing_direction.normalized * 5.0f));
        // SetPositions requires a array 
        Vector3[] _positions = new Vector3[array_counter];
        for (int i = 0; i < array_counter; i++)
        {
            _positions[i] = ray_positions[i];
        }
        line_render.positionCount = _positions.Length;
        line_render.SetPositions(_positions);
    }
}
