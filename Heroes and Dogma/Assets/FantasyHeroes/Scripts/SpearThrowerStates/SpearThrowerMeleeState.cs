using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowerMeleeState : ISpearThrowerState
{
    private float attackTimer;
    private float attackCoolDown = 5f;
    private bool canattack = true;

    private Spearthrower spearthrower;

    public void Enter(Spearthrower spearthrower)
    {
        this.spearthrower = spearthrower;
    }

    public void Execute()
    {
        Attack();
        if (spearthrower.InThrowRange && !spearthrower.InMeleeRange)
        {
            spearthrower.ChangeState(new SpearThrowerRangedState());
        }
        else if (spearthrower.Target == null)
        {
            spearthrower.ChangeState(new SpearThrowerIdleState());
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
            spearthrower.MyAnimator.SetTrigger("attack");
        }
    }
}
