using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skullspawn : MonoBehaviour
{


    public Transform ProjectilePos;
    public GameObject ProjectilePrefab;
    private float Timer= Random.Range(1, 5);

    void Start()
    {

    }

    void Update()
    {
        Timer -= 1 * Time.deltaTime;
        if (Timer <= 0f)
        {
            GameObject tmp = (GameObject)Instantiate(ProjectilePrefab, ProjectilePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<ThrowAxe>().Initialize(Vector2.left);
            Timer = Random.Range(1, 5);
        }
    }
}
 
