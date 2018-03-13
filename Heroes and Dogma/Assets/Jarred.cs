﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jarred : Control
{
    GameObject tmp;
    
    private float throwTimer;
    private float throwCoolDown = 3f;
    private bool canThrow = false;
    public GameObject skillicon1;

    public override void HandleInput() // where we put in controls (we can use this to make 2-3 player games
    {
        if (Input.GetButtonDown("Jump_P1"))
        {
            MyAnimator.SetTrigger("jump");
        }

        if (Input.GetButton("Crouch_P1"))
        {
            MyAnimator.SetBool("crouch", true);
        }

        if (Input.GetButtonDown("Attack_P1"))
        {
            MyAnimator.SetTrigger("attack");
        }

        if (Input.GetButtonDown("Skill1_P1"))
        {
            MyAnimator.SetTrigger("throw");
        }
        if (Input.GetButtonDown("Skill2_P1"))
        {
            MyAnimator.SetTrigger("cast");
        }

        if (Input.GetButtonDown("Skill3_P1"))
        {
            MyAnimator.SetTrigger("slide");
        }
    }
    public override void FixedUpdate()
    {
        throwTimer += Time.deltaTime;
        if (!TakingDamage && !IsDead)
        {
            float horizontal = Input.GetAxis("Horizontal_P1"); // "HORIZONTAL" is the name of a unity feature for movement control. You can see it in Edit>Project Settings>Input.
            OnGround = IsGrounded();
            HandleMovement(horizontal);
            Flip(horizontal);
        }
    }

    public override void ThrowKnife(int value)
    {
        Physics2D.IgnoreLayerCollision(10, 11);
    if (throwTimer >= throwCoolDown)
    {
        canThrow = true;
    }
    if (canThrow)
    {
            //skillicon1.GetComponent<Renderer>().enabled = true; attempt at making cooldown icon
            if (facingRight)
            {
                    tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                    tmp.GetComponent<Knife>().Initialize(Vector2.right);
            }
            else
            {
                    tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                    tmp.GetComponent<Knife>().Initialize(Vector2.left);
            }
            canThrow = false;
            //skillicon1.GetComponent<Renderer>().enabled = false;
            throwTimer = 0;
        }
    }


    public void Skill2()
    {
        transform.position = tmp.transform.position;
        Destroy(tmp);
    }
}


