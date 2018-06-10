using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneEnd : MonoBehaviour {
    [SerializeField]
    private float countdown;

    // Use this for initialization
    void Start () {
        StartCoroutine(JumpToScene());
	}
	
    IEnumerator JumpToScene()
    {
        yield return new WaitForSeconds(countdown);
        SceneManager.LoadScene("Character select 2");
    }


	// Update is called once per frame
	void Update () {
		
	}
}
