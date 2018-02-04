﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character1 : MonoBehaviour
{


    [SerializeField]
    protected Transform knifePos;

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;

    [SerializeField]
    public GameObject knifePrefab;

    [SerializeField]
    protected Stat healthStat;

    [SerializeField]
    private EdgeCollider2D swordCollider;

    [SerializeField]
    private List<string> damageSources;

    [SerializeField]
    private List<string> healSources;

    [SerializeField]
    public GameObject healeffectPrefab;

    [SerializeField]
    protected Transform characterPos;


    public abstract bool IsDead { get; }

    public bool Attack { get; set; }

    public bool TakingDamage { get; set; }

    public Animator MyAnimator { get; private set; }

    public EdgeCollider2D SwordCollider
    {
        get
        {
            return swordCollider;
        }


    }

    // Use this for initialization
    public virtual void Start()
    {
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
        healthStat.Initialize(); //initializes the health bar so that it starts at full life
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract IEnumerator TakeDamage();

    public abstract IEnumerator heal();

    public abstract void Disappear();

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * 1, 1);

    }

    public virtual void ThrowKnife(int value)
    {
        Physics2D.IgnoreLayerCollision(10, 11);

        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.right);

        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.left);

        }

    }

    public virtual void MeleeAttack()
    {
        Physics2D.IgnoreLayerCollision(10, 11);
        SwordCollider.enabled = true;
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (damageSources.Contains(other.tag))
        {
            StartCoroutine(TakeDamage());
        }
        if (healSources.Contains(other.tag))
        {
            StartCoroutine(heal());
            GameObject tmp = (GameObject)Instantiate(healeffectPrefab, characterPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<healeffect>().Initialize(Vector2.down);
        }
    }
}
