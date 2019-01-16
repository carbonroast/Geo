using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Creature
{
    public float move_speed;
    // Start is called before the first frame update
    void Start()
    {
        hp = 5.0f;
        this.gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Move()
    {

    }

}
