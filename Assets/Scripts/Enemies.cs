using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Creature
{
    public float move_speed;

    [SerializeField]
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        hp = 5.0f;
        this.gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            FindRandomPlayer();
        }
    }

    private void FixedUpdate()
    {

        if(target)
        {
            LookAt();
        }
    }
    public virtual void Move()
    {

    }
    public virtual void FindRandomPlayer()
    {
        GameObject[] _players = GameObject.FindGameObjectsWithTag("Player");
        target = _players[Random.Range(0, _players.Length)];
    }
    public virtual void LookAt()
    {
        Vector3 _direction = target.transform.position - this.transform.position;

        Quaternion _target_roation = Quaternion.LookRotation(_direction, Vector3.up);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, _target_roation, Time.deltaTime * 2.0f);
        
    }
}
