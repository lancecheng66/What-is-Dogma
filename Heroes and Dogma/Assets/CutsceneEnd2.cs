using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneEnd2 : MonoBehaviour {

    [SerializeField]
    private float countdown;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(JumpToScene());
    }

    IEnumerator JumpToScene()
    {
        yield return new WaitForSeconds(countdown);
        SceneManager.LoadScene("Character select 3");
    }


    // Update is called once per frame
    void Update()
    {

    }
}

