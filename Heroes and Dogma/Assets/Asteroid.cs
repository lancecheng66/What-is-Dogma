using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    public float speed;

    public GameObject Smoke;
    private Rigidbody2D myRigidbody;
    private Vector2 direction;
    
    float delay = 4f;
    float countdown;

    // Use this for initialization
    void Start()
    {
        countdown = delay;
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddTorque(1 * 1 * -100);
        //Physics2D.IgnoreLayerCollision(8, 11);
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = direction * speed;
        
        
    }
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Instantiate(Smoke, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

        }
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
