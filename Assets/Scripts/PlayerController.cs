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
        invert = true;
        body = GetComponent<Rigidbody>();
        this.gameObject.layer = LayerMask.NameToLayer("Player");

    }

    // Update is called once per frame
    void Update()
    {
        MoveCursor();
        
        if (Input.GetButtonDown("Fire1"))
        {
            Ray _ray = GetCursor();
            Shoot(_ray);
        }

    }

    private void FixedUpdate()
    {

    }

    private void MoveCursor()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");
        cursor_position.x += inputs.x * scale;
        cursor_position.z -= inputs.z * scale;

    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(cursor_position.x - 16, cursor_position.z - 16, 40, 40), cursor);
    }

    private void Shoot(Ray ray)
    {
        Quaternion _rotation = Quaternion.LookRotation(ray.direction);
        GameObject _go = Instantiate(weapon);
        Weapon _weapon = _go.GetComponent<Weapon>();
        _weapon.position = this.transform.position + new Vector3(0,0,0.01f);
        _weapon.rotation = _rotation;
        _weapon.direction = ray.direction;
    }

    private Ray GetCursor()
    {
        //Ray starts at bottom left, texture starts at the top left
        Ray _ray = Camera.main.ScreenPointToRay(new Vector2 (cursor_position.x, -cursor_position.z + Screen.height));
        return _ray;
    }
}
