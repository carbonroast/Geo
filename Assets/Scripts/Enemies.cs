using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Creature
{
    public float move_speed;
    public GameObject attack;

    [SerializeField]
    private GameObject target;
    private Quaternion target_roation;
    private MonsterState state;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        state = MonsterState.Idle;
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
        else
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {

        if(target)
        {
            state = MonsterState.Turning;
            LookAt();

        }
    }
    public virtual void Move()
    {

    }
    public virtual void Attack()
    {
        GameObject _attack = Instantiate(attack);
        Weapon _weapon = _attack.GetComponent<Weapon>();
        _weapon.position = this.transform.position;
        _weapon.rotation = target_roation;
        _weapon.direction = direction;
        _weapon.force = 60;
        _weapon.target_layer = "Player";
    }



    public virtual void FindRandomPlayer()
    {
        GameObject[] _players = GameObject.FindGameObjectsWithTag("Player");
        target = _players[Random.Range(0, _players.Length)];
    }
    public virtual void LookAt()
    {
        direction = target.transform.position - this.transform.position;
        target_roation = Quaternion.LookRotation(direction, Vector3.up);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target_roation, Time.deltaTime * 2.0f);
        
    }
}
