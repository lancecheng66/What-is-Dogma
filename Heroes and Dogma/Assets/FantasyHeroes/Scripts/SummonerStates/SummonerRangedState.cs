using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerRangedState : ISummonerState
{
    private Summoner summoner;

    private float throwTimer;
    private float throwCoolDown = 10f;
    private bool canThrow = true;

    public void Enter(Summoner summoner)
    {
        this.summoner = summoner;
    }

    public void Execute()
    {
        ThrowKnife();
        if (summoner.InMeleeRange)
        {
            summoner.ChangeState(new SummonerMeleeState());
        }
        else if (summoner.Target != null)
        {
            summoner.Move();
        }
        else
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
            summoner.MyAnimator.SetTrigger("throw");
        }
    }
}
