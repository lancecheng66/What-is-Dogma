using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public float throwforce;
    public GameObject Explosion;
    private Rigidbody2D myRigidbody;

    private Vector2 direction;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 12);
        myRigidbody = GetComponent<Rigidbody2D>();

        if (transform.localRotation.z > 0)
        {
            myRigidbody.AddTorque(1 * 1 * 50);
            myRigidbody.AddForce(new Vector2(-1, 1f) * throwforce, ForceMode2D.Impulse);
        }
        else
        {
            myRigidbody.AddForce(new Vector2(1, 1f) * throwforce, ForceMode2D.Impulse);
            myRigidbody.AddTorque(1 * 1 * -50);
        }
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Player")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
