using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerIdleState : ISummonerState
{
    private Summoner summoner;
    private float idleTimer;
    private float idleDuration;

    public void Enter(Summoner summoner)
    {
        idleDuration = UnityEngine.Random.Range(1, 10);
        this.summoner = summoner;
    }

    public void Execute()
    {

        Idle();
        if (summoner.Target != null)
        {
            Debug.Log("Player Detected");
            summoner.ChangeState(new SummonerPatrolState());
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
    private void Idle()
    {
        summoner.MyAnimator.SetFloat("Speed", 0);
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            summoner.ChangeState(new SummonerPatrolState());
        }
    }
}
