using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpearThrowerState
{
    void Execute();
    void Enter(Spearthrower spearthrower);
    void Exit();
    void OnTriggerEnter(Collider2D other);
}
