using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndExplosion : MonoBehaviour {

    float destroyTime = 1f;
    // Use this for initialization
    void Start () {
        Physics2D.IgnoreLayerCollision(11, 10);
    }
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, destroyTime);
    }
}
