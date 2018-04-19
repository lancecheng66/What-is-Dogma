using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerSight : MonoBehaviour
{

    [SerializeField]
    private Summoner summoner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            summoner.Target = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            summoner.Target = null;
        }
    }
}
