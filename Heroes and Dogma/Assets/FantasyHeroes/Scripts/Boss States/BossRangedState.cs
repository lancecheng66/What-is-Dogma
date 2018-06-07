using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRangedState : IBossState { 

    private Boss boss;

    private float throwTimer;
    private float throwCoolDown = 10f;
    private bool canThrow = true;

    public void Enter(Boss boss)
    {
        this.boss = boss;
    }

    public void Execute()
    {
        ThrowKnife();
        if (boss.InMeleeRange)
        {
            boss.ChangeState(new BossMeleeState());
        }
        else if (boss.Target != null)
        {
            boss.Move();
        }
        else
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
            boss.MyAnimator.SetTrigger("throw");
        }
    }
}
