using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorPatrolState : IWarriorState
{
    private Warrior warrior;
    private float patrolTimer;
    private float patrolDuration = 10;
    public void Enter(Warrior warrior)
    {
        patrolDuration = UnityEngine.Random.Range(1, 10);
        this.warrior = warrior;
    }

    public void Execute()
    {

        Patrol();

        warrior.Move();
        if (warrior.Target != null && warrior.InMeleeRange)
        {

            warrior.ChangeState(new WarriorMeleeState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

        if (other.tag == "PlayerProjectile")
        {
            warrior.Target = GameObject.FindWithTag("Player");
        }
    }
    private void Patrol()
    {

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            warrior.ChangeState(new WarriorIdleState());
        }
    }
}