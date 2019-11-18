using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterVolume : MonoBehaviour
{
    TextMeshProUGUI currentCharacterVolume;
    public static int characterVolume = 100;

    void Start() {
        currentCharacterVolume = GetComponent<TextMeshProUGUI> ();
        currentCharacterVolume.text = characterVolume.ToString() + "/100";
    }

    public void textUpdate(float value)
    {
        characterVolume = Mathf.RoundToInt(value * 100);
        currentCharacterVolume.text = characterVolume.ToString() + "/100";
    }
}
