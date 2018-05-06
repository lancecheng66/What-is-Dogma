using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour {

    [SerializeField]
    private Enemy enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Physics2D.IgnoreLayerCollision(11, 10);
        if (other.tag == "Player")
        {
            enemy.Target = other.gameObject;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Physics2D.IgnoreLayerCollision(11, 10);
        if (other.tag== "Player")
        {
            enemy.Target = null;
        }
       
    }
}
