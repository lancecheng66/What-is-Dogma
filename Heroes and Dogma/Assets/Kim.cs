using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kim : Control
{
    [SerializeField]
    protected Transform PandaPos;

    [SerializeField]
    public GameObject PandaPrefab;

    [SerializeField]
    protected Transform boltPos;

    [SerializeField]
    public GameObject boltPrefab;

    [SerializeField]
    public Transform WhipPos;

    [SerializeField]
    public GameObject WhipPrefab;

    [SerializeField]
    public Transform RocketPos;

    [SerializeField]
    public GameObject RocketPrefab;

    private float throwTimer;
    private float throwTimer2;
    private float throwTimer3;
    private float throwCoolDown = 15;
    private float throwCoolDown2 = 40;
    private float throwCoolDown3 = 0;
    private bool canThrow = false;
    private bool canThrow2 = false;
    private bool canThrow3 = false;

    public override void HandleInput() // where we put in controls (we can use this to make 2-3 player games
    {
        if (Input.GetButtonDown("Jump_P3"))
        {
            MyAnimator.SetTrigger("jump");
        }

        if (Input.GetButton("Crouch_P3"))
        {
            MyAnimator.SetBool("crouch", true);
        }

        if (Input.GetButtonDown("Attack_P3"))
        {
            MyAnimator.SetTrigger("attack");
        }

        if (Input.GetButtonDown("Skill1_P3"))
        {
            MyAnimator.SetTrigger("throw");
        }
        if (Input.GetButtonDown("Skill2_P3"))
        {
            MyAnimator.SetTrigger("cast");
        }

        if (Input.GetButtonDown("Skill3_P3"))
        {
            MyAnimator.SetTrigger("slide");
        }

    }

    public override void FixedUpdate()
    {
        throwTimer += Time.deltaTime;
        throwTimer2 += Time.deltaTime;
        throwTimer3 += Time.deltaTime;
        if (!TakingDamage && !IsDead)
        {
            float horizontal = Input.GetAxis("Horizontal_P3"); // "HORIZONTAL" is the name of a unity feature for movement control. You can see it in Edit>Project Settings>Input.
            OnGround = IsGrounded();
            HandleMovement(horizontal);
            Flip(horizontal);
        }

        throwTimer += Time.deltaTime;
    }

    public override void ThrowKnife(int value)
    {
        if (throwTimer >= throwCoolDown)
        {
            canThrow = true;
        }
        if (canThrow)
        {
            Physics2D.IgnoreLayerCollision(10, 11);
            if (facingRight)
            {
                GameObject tmp = (GameObject)Instantiate(PandaPrefab, PandaPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tmp.GetComponent<Panda>().Initialize(Vector2.right);
            }
            else
            {
                GameObject tmp = (GameObject)Instantiate(PandaPrefab, PandaPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tmp.GetComponent<Panda>().Initialize(Vector2.left);

            }
            canThrow = false;
            throwTimer = 0;
        }
    }

    public override void MeleeAttack()
    {
        if (throwTimer3 >= throwCoolDown3)
        {
            canThrow3 = true;
        }
        if (canThrow3)
        {
            Physics2D.IgnoreLayerCollision(10, 11);

            if (facingRight)
            {
                GameObject tmp = (GameObject)Instantiate(WhipPrefab, WhipPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tmp.GetComponent<Purplebolt>().Initialize(Vector2.right);
            }
            else
            {
                GameObject tmp = (GameObject)Instantiate(WhipPrefab, WhipPos.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                tmp.GetComponent<Purplebolt>().Initialize(Vector2.left);
            }
            canThrow3 = false;
            throwTimer3 = 0;
        }
    }

    public void Skill2()
    {
        if (throwTimer2 >= throwCoolDown2)
        {
            canThrow2 = true;
        }
        if (canThrow2)
        {
            Physics2D.IgnoreLayerCollision(10, 11);

            if (facingRight)
            {
                GameObject tmp = (GameObject)Instantiate(RocketPrefab, RocketPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                tmp.GetComponent<Rocket>().Initialize(Vector2.right); //change knife to fireball so that you can code different behavior for explosions
            }
            else
            {
                GameObject tmp = (GameObject)Instantiate(RocketPrefab, RocketPos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                tmp.GetComponent<Rocket>().Initialize(Vector2.left); //change knife to fireball so that you can code different behavior for explosions
            }
            canThrow2 = false;
            throwTimer2 = 0;
        }
    }
}

