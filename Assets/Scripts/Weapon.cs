using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float hp;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 direction;
    public float damage;
    public float force;
    public string target_layer;


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

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(target_layer))
        {
            Creature creature = other.GetComponent<Creature>();
            creature.TakeDamage(damage);
            Debug.Log(creature.GetComponent<Transform>().name + ": " + creature.hp);
        }

    }
}
