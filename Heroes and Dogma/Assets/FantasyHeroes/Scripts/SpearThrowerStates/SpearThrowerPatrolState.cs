using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowerPatrolState : ISpearThrowerState
{
    private Spearthrower spearthrower;
    private float patrolTimer;
    private float patrolDuration = 10;
    public void Enter(Spearthrower spearthrower)
    {
        patrolDuration = UnityEngine.Random.Range(1, 10);
        this.spearthrower = spearthrower;
    }

    public void Execute()
    {

        Patrol();

        spearthrower.Move();
        if (spearthrower.Target != null && spearthrower.InThrowRange)
        {

            spearthrower.ChangeState(new SpearThrowerRangedState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

        if (other.tag == "PlayerProjectile")
        {
            spearthrower.Target = GameObject.FindWithTag("Player");
        }
    }
    private void Patrol()
    {

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            spearthrower.ChangeState(new SpearThrowerIdleState());
        }
    }
}
