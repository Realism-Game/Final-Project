using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BgVolume : MonoBehaviour
{
    TextMeshProUGUI currentBgVolume;
    public int backgroundVolume = 100;
    public AudioSource gameMenuAudio;
    public AudioSource bgAudio;

    void Start() {
        currentBgVolume = GetComponent<TextMeshProUGUI> ();
        currentBgVolume.text = backgroundVolume.ToString() + "/100";
    }

    public void textUpdate(float value)
    {
        backgroundVolume = Mathf.RoundToInt(value * 100);
        currentBgVolume.text = backgroundVolume.ToString() + "/100";

        float newVolumeValue = (float) (backgroundVolume / 100);
        gameMenuAudio.volume = newVolumeValue;
        bgAudio.volume = newVolumeValue;
    }
}
