using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowerIdleState : ISpearThrowerState
{
    private Spearthrower spearthrower;
    private float idleTimer;
    private float idleDuration;

    public void Enter(Spearthrower spearthrower)
    {
        idleDuration = UnityEngine.Random.Range(1, 10);
        this.spearthrower = spearthrower;
    }

    public void Execute()
    {

        Idle();
        if (spearthrower.Target != null)
        {
            Debug.Log("Player Detected");
            spearthrower.ChangeState(new SpearThrowerPatrolState());
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
    private void Idle()
    {
        spearthrower.MyAnimator.SetFloat("Speed", 0);
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            spearthrower.ChangeState(new SpearThrowerPatrolState());
        }
    }
}