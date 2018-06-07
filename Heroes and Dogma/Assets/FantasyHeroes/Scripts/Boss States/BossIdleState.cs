using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : IBossState

{
    private Boss boss;
    private float idleTimer;
    private float idleDuration;

    public void Enter(Boss boss)
    {
        idleDuration = UnityEngine.Random.Range(1, 10);
        this.boss = boss;
    }

    public void Execute()
    {

        Idle();
        if (boss.Target != null)
        {
            Debug.Log("Player Detected");
            boss.ChangeState(new BossPatrolState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "PlayerProjectile")
        {
            boss.Target = GameObject.FindWithTag("Player");
        }
    }
    private void Idle()
    {
        boss.MyAnimator.SetFloat("Speed", 0);
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
        {
            boss.ChangeState(new BossPatrolState());
        }
    }
}