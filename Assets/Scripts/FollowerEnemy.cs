using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : Enemy
{

    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        Move();
    }


    protected override void Attack()
    {
    }

    protected override void Move()
    {
        enemy.SetDestination(player.position);
    }
}
