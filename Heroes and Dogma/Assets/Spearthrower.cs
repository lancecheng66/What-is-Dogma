using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearthrower : Enemy
{
   

    public override void ThrowKnife(int value)
    {

        Physics2D.IgnoreLayerCollision(9, 12);

        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(ProjectilePrefab, ProjectilePos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(ProjectilePrefab, ProjectilePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.left);

        }
    }
}
