using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerPatrolState : ISummonerState
{
    private Summoner summoner;
    private float patrolTimer;
    private float patrolDuration = 10;
    public void Enter(Summoner summoner)
    {
        patrolDuration = UnityEngine.Random.Range(1, 10);
        this.summoner = summoner;
    }

    public void Execute()
    {

        Patrol();

        summoner.Move();
        if (summoner.Target != null && summoner.InThrowRange)
        {

            summoner.ChangeState(new SummonerRangedState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

        if (other.tag == "PlayerProjectile")
        {
            summoner.Target = GameObject.FindWithTag("Player");
        }
    }
    private void Patrol()
    {

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            summoner.ChangeState(new SummonerIdleState());
        }
    }
}
