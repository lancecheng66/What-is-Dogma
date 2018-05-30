using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(JumpToScene());
	}
	
    IEnumerator JumpToScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Character Select");
    }


	// Update is called once per frame
	void Update () {
		
	}
}
