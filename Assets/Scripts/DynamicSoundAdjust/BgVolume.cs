using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BgVolume : MonoBehaviour
{
    TextMeshProUGUI currentBgVolume;
    public int backgroundVolume;

    void Start() {
        currentBgVolume = GetComponent<TextMeshProUGUI> ();
        backgroundVolume = 100; // Set default value when start game
        currentBgVolume.text = backgroundVolume.ToString() + "/100";
    }

    public void textUpdate(float value)
    {
        backgroundVolume = Mathf.RoundToInt(value * 100);
        currentBgVolume.text = backgroundVolume.ToString() + "/100";
    }
}
