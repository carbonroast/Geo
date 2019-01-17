using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public float hp;

    public virtual void TakeDamage(float damage)
    {

        hp -= damage;
        Debug.Log("HIT:" + hp + " left");
        if (hp <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(this.gameObject);
    }
}
