using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public float hp;
    public float attack_start;
    public float attack_cooldown;
    public GameObject weapon;

    public virtual void TakeDamage(float damage)
    {

        hp -= damage;
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
