using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorIdleState : IWarriorState
{
    private Warrior warrior;
    private float idleTimer;
    private float idleDuration;

    public void Enter(Warrior warrior)
    {
        idleDuration = UnityEngine.Random.Range(1, 10);
        this.warrior = warrior;
    }

    public void Execute()
    {

        Idle();
        if (warrior.Target != null)
        {

            warrior.ChangeState(new WarriorPatrolState());
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
    private void Idle()
    {
        warrior.MyAnimator.SetFloat("Speed", 0);
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            warrior.ChangeState(new WarriorPatrolState());
        }
    }
}
