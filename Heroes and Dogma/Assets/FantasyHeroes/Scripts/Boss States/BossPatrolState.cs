using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrolState : IBossState
{

    private Boss boss;
    private float patrolTimer;
    private float patrolDuration = 10;
    public void Enter(Boss boss)
    {
        patrolDuration = UnityEngine.Random.Range(1, 10);
        this.boss = boss;
    }

    public void Execute()
    {

        Patrol();

        boss.Move();
        if (boss.Target != null && boss.InThrowRange)
        {

            boss.ChangeState(new BossRangedState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

        if (other.tag == "PlayerProjectile")
        {
            boss.Target = GameObject.FindWithTag("Player");
        }
    }
    private void Patrol()
    {

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            boss.ChangeState(new BossIdleState());
        }
    }
}
