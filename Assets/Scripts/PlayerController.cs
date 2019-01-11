using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject weapon;
    public Vector3 velo;
    
    private Rigidbody body;
    private Vector3 inputs;

    
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;

        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        body.velocity = inputs * speed;
        if(body.velocity != Vector3.zero)
        {
            this.transform.rotation = Quaternion.LookRotation(body.velocity);
        }
        velo = body.velocity;
    }

    private void Shoot()
    {
        GameObject _go = Instantiate(weapon);
        Laser _weapon = _go.GetComponent<Laser>();
        _weapon.position = body.position;
        _weapon.rotation = this.transform.rotation;
    }
}
