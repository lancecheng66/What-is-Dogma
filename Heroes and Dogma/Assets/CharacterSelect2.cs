﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect2 : MonoBehaviour
{

    private GameObject[] characterList;

    private void Start()
    {
        characterList = new GameObject[transform.childCount];
        // fill array with models
        for (int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;
        // turn off their renderer
        foreach (GameObject go in characterList)
            go.SetActive(false);
    }


    public void Kayla()
    {
        characterList[0].SetActive(true);
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Jarred()
    {
        characterList[1].SetActive(true);
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Sven()
    {
        characterList[2].SetActive(true);
        DontDestroyOnLoad(transform.gameObject);
    }
    public void Anastasia()
    {
        characterList[3].SetActive(true);
        DontDestroyOnLoad(transform.gameObject);
    }
    public void Lance()
    {
        characterList[4].SetActive(true);
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Michael()
    {
        characterList[5].SetActive(true);
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Kim()
    {
        characterList[6].SetActive(true);
        DontDestroyOnLoad(transform.gameObject);
    }
    public void Iris()
    {
        characterList[7].SetActive(true);
        DontDestroyOnLoad(transform.gameObject);
    }
    public void ConfirmButton()
    {
        SceneManager.LoadScene("Stage 2");
    }

}
