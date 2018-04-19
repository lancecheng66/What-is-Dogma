using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSight : MonoBehaviour
{
    [SerializeField]
    private Warrior warrior;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            warrior.Target = other.gameObject;
       
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            warrior.Target = null;
        }
    }
}
