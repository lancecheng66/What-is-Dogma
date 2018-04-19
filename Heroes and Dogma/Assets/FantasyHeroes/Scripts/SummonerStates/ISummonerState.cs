using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISummonerState
{
    void Execute();
    void Enter(Summoner summoner);
    void Exit();
    void OnTriggerEnter(Collider2D other);
}
