using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    public GameObject Explosion;
    public float throwforce;
    private Rigidbody2D myRigidbody;
    private Vector2 direction;
    float delay = 3f;
    float countdown;
    // Use this for initialization

    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 10);
        countdown = delay;
        myRigidbody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
            myRigidbody.AddForce(new Vector2(1, 1.3f) * throwforce, ForceMode2D.Impulse);
        else
            myRigidbody.AddForce(new Vector2(-1, 1.3f) * throwforce, ForceMode2D.Impulse);

        myRigidbody.AddTorque(1 * 1 * 1);
    }

    void FixedUpdate()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown<=0)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
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