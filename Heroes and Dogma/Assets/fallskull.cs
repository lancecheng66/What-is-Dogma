using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallskull : MonoBehaviour
{
    

    private Rigidbody2D myRigidbody;

    private Vector2 direction;
    float destroyTime = 10f;
    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 12);
        myRigidbody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
            myRigidbody.AddForce(new Vector2(-1, 2) * Random.Range(1, 15), ForceMode2D.Impulse);
        else
            myRigidbody.AddForce(new Vector2(1, 2) * Random.Range(1, 15), ForceMode2D.Impulse);

        myRigidbody.AddTorque(1 * 1 * -35);
    }

    void FixedUpdate()
    {


    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}