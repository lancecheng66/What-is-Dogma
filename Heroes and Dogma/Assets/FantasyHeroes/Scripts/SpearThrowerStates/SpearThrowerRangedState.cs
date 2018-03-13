using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowerRangedState : ISpearThrowerState
{
    private Spearthrower spearthrower;
    private float throwTimer;
    private float throwCoolDown = 50f;
    private bool canThrow=true;

    public void Enter(Spearthrower spearthrower)
    {
        this.spearthrower = spearthrower;
        throwTimer += Time.deltaTime;
    }
    
        public void Execute()
    {
        ThrowKnife();
        
        spearthrower.ChangeState(new SpearThrowerIdleState());
        
    }
   
    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }
    private void ThrowKnife()
    {
        if (throwTimer >= throwCoolDown)
        {
            canThrow = true;
        }
        if (canThrow)
        {
            spearthrower.MyAnimator.SetTrigger("throw");
            canThrow = false;
            throwTimer = 0;
           
        }
    }
}
