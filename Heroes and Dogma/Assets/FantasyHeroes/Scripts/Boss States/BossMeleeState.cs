using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeState : IBossState
{


    private float attackTimer;
    private float attackCoolDown = 5f;
    private bool canattack = true;

    private Boss boss;

    public void Enter(Boss boss)
    {
        this.boss = boss;
    }

    public void Execute()
    {
        Attack();
        if (boss.InThrowRange && !boss.InMeleeRange)
        {
            boss.ChangeState(new BossRangedState());
        }
        else if (boss.Target == null)
        {
            boss.ChangeState(new BossIdleState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }

    private void Attack()
    {

        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCoolDown)
        {
            canattack = true;
            attackTimer = 0;
        }
        if (canattack)
        {
            canattack = false;
            boss.MyAnimator.SetTrigger("attack");
        }
    }
}
