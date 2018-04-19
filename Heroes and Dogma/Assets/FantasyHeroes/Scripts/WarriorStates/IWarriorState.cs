using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWarriorState
{
    void Execute();
    void Enter(Warrior warrior);
    void Exit();
    void OnTriggerEnter(Collider2D other);
}

