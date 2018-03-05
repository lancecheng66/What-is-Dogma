using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowerRangedState : ISpearThrowerState
{
    private Spearthrower spearthrower;

    private float throwTimer;
    private float throwCoolDown = 10f;
    private bool canThrow = true;

    public void Enter(Spearthrower spearthrower)
    {
        this.spearthrower = spearthrower;
    }

    public void Execute()
    {
        ThrowKnife();
        if (spearthrower.InMeleeRange)
        {
            spearthrower.ChangeState(new SpearThrowerMeleeState());
        }
        else if (spearthrower.Target != null)
        {
            spearthrower.Move();
        }
        else
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
            spearthrower.MyAnimator.SetTrigger("throw");
        }
    }
}
