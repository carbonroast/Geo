using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Creature
{
    public float move_speed;


    [SerializeField]
    private GameObject target;
    private Quaternion target_roation;
    private MonsterState state;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        state = MonsterState.Idle;
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
            if(state == MonsterState.Attacking)
            {
                Attack();
            }

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
    public virtual void Attack()
    {
        if(Time.time > attack_start + attack_cooldown)
        {

            GameObject _attack = Instantiate(weapon);
            Weapon _weapon = _attack.GetComponent<Weapon>();
            _weapon.position = this.transform.Find("FirePoint").transform.position;
            _weapon.rotation = target_roation;
            _weapon.direction = direction;
            _weapon.target_layer = "Player";
            attack_start = Time.time;
        }

    }



    public virtual void FindRandomPlayer()
    {
        GameObject[] _players = GameObject.FindGameObjectsWithTag("Player");
        target = _players[Random.Range(0, _players.Length)];
    }
    public virtual void LookAt()
    {

        direction = target.transform.position - this.transform.Find("FirePoint").transform.position;
        target_roation = Quaternion.LookRotation(direction, Vector3.up);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target_roation, Time.deltaTime * 2.0f);
        float angle = Quaternion.Angle(this.transform.rotation, target_roation);
        if (angle <= 1.0f)
        {
            state = MonsterState.Attacking;
        }
        else
        {
            state = MonsterState.Turning;
        }

    }
}
