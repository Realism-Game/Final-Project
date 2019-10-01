using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterInputController[] ControllableCharacters = { };

    public Camera thirdPersonCamera;

    protected int nextCharacterIndex = 0;

    protected void DisableAllCharacters()
    {

        foreach (CharacterInputController c in ControllableCharacters)
        {
            c.enabled = false;
        }

    }

    protected void SetCharacter(int charIndex)
    {

        DisableAllCharacters();

        if (charIndex < 0)
            charIndex = 0;

        if (charIndex >= ControllableCharacters.Length)
            charIndex = ControllableCharacters.Length - 1;
        CharacterInputController currentChar = ControllableCharacters[charIndex];
        currentChar.enabled = true;
        thirdPersonCamera.transform.position = currentChar.transform.position 
            - new Vector3(currentChar.transform.forward.x * 5, -2, currentChar.transform.forward.z * 5);
        thirdPersonCamera.transform.forward = currentChar.transform.forward;
        
    }

    protected void IncrementCharacterIndex()
    {

        ++nextCharacterIndex;

        if (nextCharacterIndex < 0 || nextCharacterIndex >= ControllableCharacters.Length)
            nextCharacterIndex = 0;
    }

    protected void ToggleCharacter()
    {

        SetCharacter(nextCharacterIndex);
        IncrementCharacterIndex();
    }


    void Start()
    {
        SetCharacter(nextCharacterIndex);
        IncrementCharacterIndex();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            ToggleCharacter();
        }
    }
}
