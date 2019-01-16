using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 direction;
    public float damage;

    public virtual void Start()
    {
        SetRotation();
        this.transform.position = position;
    }
    public virtual void Destroy(float time)
    {
        Destroy(this.gameObject,time);
    }


    public virtual void Damage()
    {

    }
    public virtual void SetRotation()
    {
        this.transform.rotation = rotation;
    }
}
