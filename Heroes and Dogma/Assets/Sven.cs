using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sven : Control
{
    public bool shield { get; set; }
    [SerializeField]
    protected Transform ShieldPos;

    [SerializeField]
    public GameObject ShieldPrefab;

    [SerializeField]
    protected Transform ChastisePos;

    [SerializeField]
    public GameObject ChastisePrefab;

    private float throwTimer;
    private float throwTimer2;
    private float throwCoolDown = 3f;
    private float throwCoolDown2 = 10f;
    private bool canThrow = false;
    private bool canThrow2 = false;

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

        if (Input.GetButton("Skill3_P3"))
        {
            MyAnimator.SetBool("shield", true);
           
        }

    }

    public override void FixedUpdate()
    {
        throwTimer += Time.deltaTime;
        throwTimer2 += Time.deltaTime;
        if (!TakingDamage && !IsDead && !shield)
        {
            float horizontal = Input.GetAxis("Horizontal_P3"); // "HORIZONTAL" is the name of a unity feature for movement control. You can see it in Edit>Project Settings>Input.
            OnGround = IsGrounded();
            HandleMovement(horizontal);
            Flip(horizontal);
            Physics2D.IgnoreLayerCollision(10, 11);
            if(shield==false)
            {
                immortal = false;
            }
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
            if (facingRight)
            {
                GameObject tmp = (GameObject)Instantiate(ShieldPrefab, ShieldPos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                tmp.GetComponent<ShieldBoomerang>().Initialize(Vector2.right);
            }
            else
            {
                GameObject tmp = (GameObject)Instantiate(ShieldPrefab, ShieldPos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                tmp.GetComponent<ShieldBoomerang>().Initialize(Vector2.left);

            }
            canThrow = false;
            //skillicon1.GetComponent<Renderer>().enabled = false;
            throwTimer = 0;
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
            GameObject tmp = (GameObject)Instantiate(ChastisePrefab, ChastisePos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Chastise>().Initialize(Vector2.down);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(ChastisePrefab, ChastisePos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Chastise>().Initialize(Vector2.down);
        }
            canThrow2 = false;
            //skillicon1.GetComponent<Renderer>().enabled = false;
            throwTimer2 = 0;
        }
    }

    public void Shield()
    {
        if (shield)
        {
            immortal = true;
        }
       
    }
}

