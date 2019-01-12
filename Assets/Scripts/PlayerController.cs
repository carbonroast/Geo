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
            Ray _ray = MoveCursor();
            Shoot(_ray);
        }

    }

    private void FixedUpdate()
    {

    }

    private void Shoot(Ray ray)
    {
        Quaternion _rotation = Quaternion.LookRotation(ray.direction);
        GameObject _go = Instantiate(weapon);
        BasicLaser _weapon = _go.GetComponent<BasicLaser>();
        _weapon.position = body.position;
        _weapon.rotation = _rotation;
    }

    private Ray MoveCursor()
    {
        
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        Vector3 _spawn_position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        return _ray;
    }
}
