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
        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(direction * force);
        Destroy(7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Damage()
    {

    }


}
