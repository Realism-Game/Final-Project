using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BgVolume : MonoBehaviour
{
    TextMeshProUGUI currentBgVolume;
    public static int backgroundVolume = 100;

    void Start() {
        currentBgVolume = GetComponent<TextMeshProUGUI> ();
        currentBgVolume.text = backgroundVolume.ToString() + "/100";
    }

    public void textUpdate(float value)
    {
        backgroundVolume = Mathf.RoundToInt(value * 100);
        currentBgVolume.text = backgroundVolume.ToString() + "/100";
    }
}
