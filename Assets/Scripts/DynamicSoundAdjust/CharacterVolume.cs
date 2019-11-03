using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterVolume : MonoBehaviour
{
    TextMeshProUGUI currentCharacterVolume;
    public int characterVolume;

    void Start() {
        currentCharacterVolume = GetComponent<TextMeshProUGUI> ();
        characterVolume = 100; // Set default value when start game
        currentCharacterVolume.text = characterVolume.ToString() + "/100";
    }

    public void textUpdate(float value)
    {
        characterVolume = Mathf.RoundToInt(value * 100);
        currentCharacterVolume.text = characterVolume.ToString() + "/100";
    }
}
