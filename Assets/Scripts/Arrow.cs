using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{
    // Start is called before the first frame update
    public override void  Start()
    {
        base.Start();
        this.gameObject.transform.Rotate(270, 0, 0);
        damage = 2.0f;
        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(direction * 50);
        Destroy(3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Damage()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Creature Enemy = other.GetComponent<Creature>();
            Enemy.TakeDamage(damage);
        }

    }
}
