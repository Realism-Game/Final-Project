using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] ControllableCharacters = { };

    public Camera thirdPersonCamera;

    protected int nextCharacterIndex = 0;

    protected void DisableAllCharacters()
    {

        foreach (GameObject c in ControllableCharacters)
        {
            c.SetActive(false);
        }

    }

    protected void SetCharacter(int charIndex)
    {

        DisableAllCharacters();

        if (charIndex < 0)
            charIndex = 0;

        if (charIndex >= ControllableCharacters.Length)
            charIndex = ControllableCharacters.Length - 1;
        GameObject currentChar = ControllableCharacters[charIndex];
        currentChar.SetActive(true);
        thirdPersonCamera.transform.position = currentChar.transform.position 
            - new Vector3(currentChar.transform.forward.x * 3, -1.5f, currentChar.transform.forward.z * 2);
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
