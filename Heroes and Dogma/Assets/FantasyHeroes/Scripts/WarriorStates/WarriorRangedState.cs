using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorRangedState : IWarriorState
{
    private Warrior warrior;

    private float throwTimer;
    private float throwCoolDown = 10f;
    private bool canThrow = true;

    public void Enter(Warrior warrior)
    {
        this.warrior = warrior;
    }

    public void Execute()
    {
        ThrowKnife();
        if (warrior.InMeleeRange)
        {
            warrior.ChangeState(new WarriorMeleeState());
        }
        else if (warrior.Target != null)
        {
            warrior.Move();
        }
        else
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
    private void ThrowKnife()
    {

        throwTimer += Time.deltaTime;
        if (throwTimer >= throwCoolDown)
        {
            canThrow = true;
            throwTimer = 0;
        }
        if (canThrow)
        {
            canThrow = false;
            warrior.MyAnimator.SetTrigger("throw");
        }
    }
}