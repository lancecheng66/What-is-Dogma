using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMeleeState : IWarriorState
{
    private float attackTimer;
    private float attackCoolDown = 5f;
    private bool canattack = true;

    private Warrior warrior;

    public void Enter(Warrior warrior)
    {
        this.warrior = warrior;
    }

    public void Execute()
    {
        Attack();
        if (warrior.InThrowRange && !warrior.InMeleeRange)
        {
            warrior.ChangeState(new WarriorRangedState());
        }
        else if (warrior.Target == null)
        {
            warrior.ChangeState(new WarriorIdleState());
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
            warrior.MyAnimator.SetTrigger("attack");
        }
    }
}
