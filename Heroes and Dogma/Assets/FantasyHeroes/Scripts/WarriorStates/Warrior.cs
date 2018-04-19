using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character1

{

    private IWarriorState currentState;
    public GameObject Target { get; set; }

    [SerializeField]
    private float meleeRange;

    [SerializeField]
    private float throwRange;

    [SerializeField]
    private Transform leftEdge;
    [SerializeField]
    private Transform rightEdge;
    private Canvas healthCanvas;

    public bool InMeleeRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
            }
            return false;
        }
    }

    public bool InThrowRange
    {
        
        get
        {
            if (Target != null)
            {
                Debug.Log("In throw range");
                return Vector2.Distance(transform.position, Target.transform.position) <= throwRange;
               
            }
            
            return false;

        }
    }

    public override bool IsDead
    {
        get
        {
            return healthStat.CurrentValue <= 0;
        }
    }


    public Transform ProjectilePos;



    public GameObject ProjectilePrefab;

    protected Warrior()
    {
    }

    // Use this for initialization
    public override void Start()
    {

        base.Start();
        //gameObject.GetComponent<Control>().Dead += new DeadEventHandler(RemoveTarget);     //WE DO NOT KNOW WHY WE REMOVED THIS. WE HAVE TO RESEARCH WHAT IT DOES.
        ChangeState(new WarriorIdleState());
        Physics2D.IgnoreLayerCollision(9, 9); //Keeps enemies from colliding with each other
        healthCanvas = transform.GetComponentInChildren<Canvas>();
    }


    public void RemoveTarget()
    {
        Target = null;
        ChangeState(new WarriorPatrolState());
    }

    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            if (!TakingDamage)
            {
                currentState.Execute();
            }
            currentState.Execute();
            LookAtTarget();
        }
    }
    public void ChangeState(IWarriorState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }

    public void Move()
    {
        if (!Attack)
        {
            if ((GetDirection().x > 0 && transform.position.x < rightEdge.position.x) || (GetDirection().x < 0 && transform.position.x > leftEdge.position.x))
            {
                MyAnimator.SetFloat("Speed", 1);
                transform.Translate(GetDirection() * movementSpeed * (Time.deltaTime));
            }
            else if (currentState is WarriorPatrolState)
            {
                ChangeDirection();
            }
        }
    }
    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left; //this is the short vestion of an if statement. If facing right> Vector2.right, if facing left>vector2.left

    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        currentState.OnTriggerEnter(other);
    }
    public override void ThrowKnife(int value)
    {

        Physics2D.IgnoreLayerCollision(9, 12);

        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(ProjectilePrefab, ProjectilePos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<ThrowAxe>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(ProjectilePrefab, ProjectilePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<ThrowAxe>().Initialize(Vector2.left);

        }
    }

    public override IEnumerator TakeDamage1()
    {
        if (!healthCanvas.isActiveAndEnabled)
        {
            healthCanvas.enabled = true;
        }

        healthStat.CurrentValue -= 10;

        if (!IsDead)
        {
            MyAnimator.SetTrigger("damage");
        }
        else
        {
            MyAnimator.SetTrigger("die");
            yield return null;

        }
    }

    public override IEnumerator TakeDamage2()
    {
        if (!healthCanvas.isActiveAndEnabled)
        {
            healthCanvas.enabled = true;
        }

        healthStat.CurrentValue -= 35;

        if (!IsDead)
        {
            MyAnimator.SetTrigger("damage");
        }
        else
        {
            MyAnimator.SetTrigger("die");
            yield return null;

        }
    }

    public override IEnumerator TakeDamage3()
    {
        if (!healthCanvas.isActiveAndEnabled)
        {
            healthCanvas.enabled = true;
        }

        healthStat.CurrentValue -= 50;

        if (!IsDead)
        {
            MyAnimator.SetTrigger("damage");
        }
        else
        {
            MyAnimator.SetTrigger("die");
            yield return null;

        }
    }

    public override IEnumerator heal()
    {
        healthStat.CurrentValue += 30;
        yield return null;
    }

    public override void Disappear()
    {

        Destroy(gameObject);
        healthCanvas.enabled = false;
    }
}

