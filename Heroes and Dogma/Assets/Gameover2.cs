using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameover2 : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject ListOfPlayers = GameObject.FindGameObjectWithTag("Player");

        {
            if (ListOfPlayers != null)
            {
                Debug.Log("all characters not dead");
            }
            else
            {
                SceneManager.LoadScene("Gameoverscreen2");
            }
            return;
        }
    }


}