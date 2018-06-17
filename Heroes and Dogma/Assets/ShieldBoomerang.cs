using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ShieldBoomerang : MonoBehaviour
{
    public float speed;
    bool returning = false;
    private Transform playertrans;

    float boomerangTimer;
    private Rigidbody2D myRigidbody;
    float destroyTime = 1f;
    private Vector2 direction;

    

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        boomerangTimer = 0.0f;
        playertrans = GameObject.Find("ShieldPos").transform;
       
    }

    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, destroyTime);
        boomerangTimer += Time.deltaTime;

        if (boomerangTimer >= 0.5f)
        {
            returning = true;
        }

        if (!returning)
        {

            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.right = playertrans.position - transform.position;
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            returning = true;

    }
}
