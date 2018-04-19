using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerMeleeState : ISummonerState
{
    private float attackTimer;
    private float attackCoolDown = 5f;
    private bool canattack = true;

    private Summoner summoner;

    public void Enter(Summoner summoner)
    {
        this.summoner = summoner;
    }

    public void Execute()
    {
        Attack();
        if (summoner.InThrowRange && !summoner.InMeleeRange)
        {
            summoner.ChangeState(new SummonerRangedState());
        }
        else if (summoner.Target == null)
        {
            summoner.ChangeState(new SummonerIdleState());
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
            summoner.MyAnimator.SetTrigger("attack");
        }
    }
}
