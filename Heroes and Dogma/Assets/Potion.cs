using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    public float throwforce;

    private Rigidbody2D myRigidbody;

    private Vector2 direction;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 12);
        myRigidbody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
            myRigidbody.AddForce(new Vector2(-0.4f,3) * throwforce, ForceMode2D.Impulse);
        else
            myRigidbody.AddForce(new Vector2(0.4f,3) * throwforce, ForceMode2D.Impulse);

        myRigidbody.AddTorque(1 * 1 * -10);
    }

    void FixedUpdate()
    {


    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}