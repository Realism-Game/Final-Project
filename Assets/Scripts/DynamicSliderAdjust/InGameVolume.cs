using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameVolume : MonoBehaviour
{
    TextMeshProUGUI currentBgVolume;
    public static int inGameVol = 0;
    public Slider gameVolumeSlider;

    void Start() {
        currentBgVolume = GetComponent<TextMeshProUGUI> ();
        inGameVol = BgVolume.backgroundVolume;
        float valToSet = (float)inGameVol / 100f;
        gameVolumeSlider.value = valToSet;
        currentBgVolume.text = inGameVol.ToString() + "/100";
    }

    public void textUpdate(Slider slider)
    {
        inGameVol = Mathf.RoundToInt(slider.value * 100);
        currentBgVolume.text = inGameVol.ToString() + "/100";
    }
}
