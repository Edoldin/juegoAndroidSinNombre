using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public    Transform    player;
    protected UnityEngine.AI.NavMeshAgent enemy;

    [SerializeField] protected Rigidbody rg;
    [SerializeField] protected int         hp;
    [SerializeField] protected int         damage;
    [SerializeField] protected float       speed;
    [SerializeField] protected float       attackSpeed;

    protected virtual void Awake()
    {
        rg = GetComponent<Rigidbody>();
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    protected virtual void Move()
    {
    }

    protected virtual void Attack()
    {
    }

    protected virtual void SetStats(int hp, int damage, float speed, float attackSpeed)
    {
        this.hp = hp;
        this.damage = damage; 
        this.speed = speed;
        this.attackSpeed = attackSpeed;
    }

    public Vector2 getPos()
    {
        return new Vector2(rg.position.x, rg.position.y);
    }
}
