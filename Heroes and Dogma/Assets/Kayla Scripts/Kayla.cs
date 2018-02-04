﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kayla : Control
{
    [SerializeField]
    protected Transform AsteroidPos;

    [SerializeField]
    public GameObject AsteroidPrefab;

    [SerializeField]
    protected Transform boltPos;

    [SerializeField]
    public GameObject boltPrefab;

    [SerializeField]
    public GameObject healboltPrefab;

    private float throwTimer;
    private float throwCoolDown = 5f;
    private bool canThrow = false;


    public override void HandleInput() // where we put in controls (we can use this to make 2-3 player games
    {
        if (Input.GetButtonDown("Jump_P2"))
        {
            MyAnimator.SetTrigger("jump");
        }

        if (Input.GetButton("Crouch_P2"))
        {
            MyAnimator.SetBool("crouch", true);
        }

        if (Input.GetButtonDown("Attack_P2"))
        {
            MyAnimator.SetTrigger("attack");
        }

        if (Input.GetButtonDown("Skill1_P2"))
        {
            MyAnimator.SetTrigger("throw");
        }
        if (Input.GetButtonDown("Skill2_P2"))
        {
            MyAnimator.SetTrigger("cast");
        }

        if (Input.GetButtonDown("Skill3_P2"))
        {
            MyAnimator.SetTrigger("slide");
        }

    }

    public override void FixedUpdate()
    {
        if (!TakingDamage && !IsDead)
        {
            float horizontal = Input.GetAxis("Horizontal_P2"); // "HORIZONTAL" is the name of a unity feature for movement control. You can see it in Edit>Project Settings>Input.
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
                GameObject tmp = (GameObject)Instantiate(AsteroidPrefab, AsteroidPos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                tmp.GetComponent<Asteroid>().Initialize(Vector2.right);
            }
            else
            {
                GameObject tmp = (GameObject)Instantiate(AsteroidPrefab, AsteroidPos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                tmp.GetComponent<Asteroid>().Initialize(Vector2.left);

            }
            canThrow = false;
            throwTimer = 0;
        }
    }

    public override void MeleeAttack()
    {
        Physics2D.IgnoreLayerCollision(10, 11);
       
            if (facingRight)
            {
                GameObject tmp = (GameObject)Instantiate(boltPrefab, boltPos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                tmp.GetComponent<Bolt>().Initialize(Vector2.right); //change knife to fireball so that you can code different behavior for explosions
            }
            else
            {
                GameObject tmp = (GameObject)Instantiate(boltPrefab, boltPos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                tmp.GetComponent<Bolt>().Initialize(Vector2.left); //change knife to fireball so that you can code different behavior for explosions

            }
        
    }

    public void Skill2()
    {
        Physics2D.IgnoreLayerCollision(10, 11);

        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(healboltPrefab, boltPos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<healbolt>().Initialize(Vector2.right); //change knife to fireball so that you can code different behavior for explosions
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(healboltPrefab, boltPos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<healbolt>().Initialize(Vector2.left); //change knife to fireball so that you can code different behavior for explosions

        }

    }
}

