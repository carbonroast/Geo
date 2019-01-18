using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public Quaternion rotation;
    public Ray ray;

    public virtual void Attack()
    {
        if (Time.time > attack_start + attack_cooldown)
        {
            GameObject _go = Instantiate(weapon);
            Weapon _weapon = _go.GetComponent<Weapon>();
            _weapon.position = this.transform.position + new Vector3(0, 0, 0.01f);
            _weapon.rotation = rotation;
            _weapon.direction = ray.direction;
            _weapon.target_layer = "Enemy";
            attack_start = Time.time;
        }
    }
    public override void TakeDamage(float damage)
    {
        hp -= damage;
    }
}
