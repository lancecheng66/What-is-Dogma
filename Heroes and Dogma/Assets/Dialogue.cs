using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour
{
    private Text _textComponent;
    public string[] DialogueStrings;
    public float SecondsBetweenCharacters = 0.15f;
    public float CHaracterRateMultiplier = 0.025f;

    public KeyCode DialogueInput = KeyCode.Return;
    private bool _IsStringBeingRevealed = false;

	// Use this for initialization
	void Start ()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Return))
        {
            if(!_IsStringBeingRevealed)
            {
                _IsStringBeingRevealed = true;
                StartCoroutine(DisplayString(DialogueStrings[0]));
            }
            
        }
	}

    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters * CHaracterRateMultiplier);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
            else
            {
                break;
            }
        }
            while (true)
            {
                if(Input.GetKeyDown(DialogueInput))
                {
                    break;
                }
            yield return 0;
            }
        _IsStringBeingRevealed = false;
        _textComponent.text = "";
    }

}
