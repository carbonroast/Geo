using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject weapon;
    public Vector3 velo;
    public Texture2D cursor;
    private Rigidbody body;
    private Vector3 inputs;
    private Vector3 cursor_position;
    private float scale = 5.0f;
    public bool invert = false;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetCursor();
        
        if (Input.GetButtonDown("Fire1"))
        {
            Ray _ray = MoveCursor();
            Shoot(_ray);
        }

    }

    private void FixedUpdate()
    {

    }

    private void GetCursor()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");
        cursor_position.x += inputs.x * scale;
        cursor_position.z -= inputs.z * scale;
        Debug.Log("x: " + inputs.x + " z: " + inputs.z);
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(cursor_position.x - 16, cursor_position.z - 16, 200, 200), cursor);
    }

    private void Shoot(Ray ray)
    {
        Quaternion _rotation = Quaternion.LookRotation(ray.direction);
        GameObject _go = Instantiate(weapon);
        BasicLaser _weapon = _go.GetComponent<BasicLaser>();
        _weapon.position = body.position + new Vector3(0,0,0.01f);
        _weapon.rotation = _rotation;
    }

    private Ray MoveCursor()
    {
        
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return _ray;
    }
}
