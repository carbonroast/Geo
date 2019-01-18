using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float hp;
    // Start is called before the first frame update

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerProjectile"))
        {
            Debug.Log("Hit Arrow");
            hp -= other.GetComponent<Weapon>().damage;
        }

    }
}
