using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowerSight : MonoBehaviour
{

    [SerializeField]
    private Spearthrower spearthrower
      ;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spearthrower.Target = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spearthrower.Target = null;
        }
    }
}
