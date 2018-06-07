using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSight : MonoBehaviour {

    [SerializeField]
    private Boss boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Physics2D.IgnoreLayerCollision(11, 10);
        if (other.tag == "Player")
        {
            boss.Target = other.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Physics2D.IgnoreLayerCollision(11, 10);
        if (other.tag == "Player")
        {
            boss.Target = null;
        }

    }
}
