using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBossState
{ 
    void Execute();
    void Enter(Boss boss);
    void Exit();
    void OnTriggerEnter(Collider2D other);
}