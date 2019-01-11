using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser  : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public LineRenderer line_render;


    public virtual void Start()
    {
        LineRender();
        SetRotation();

    }

    public virtual void SetRotation()
    {
        this.transform.rotation = rotation;
    }
    public virtual void LineRender()
    {
        line_render = GetComponent<LineRenderer>();
        line_render.startWidth = 0.04f;
        line_render.endWidth = 0.04f;
        line_render.material.color = Color.red;
    }
    
    public virtual void Destroy(float time)
    {
        GameObject.Destroy(line_render, time);
        GameObject.Destroy(this.gameObject, time);
    }

    public virtual void Damage()
    {

    }
}
