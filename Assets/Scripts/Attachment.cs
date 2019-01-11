using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachment : MonoBehaviour
{
    public int health;
    public int movespeed;
    public int body_size;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    public virtual void TakeDamage(int damage)
    {

    }

    public virtual void OnDeath()
    {

    }

}
