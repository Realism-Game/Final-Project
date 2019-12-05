using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameCharVol : MonoBehaviour
{
    TextMeshProUGUI currentBearVolText;
    public static int bearVol = 0;
    public Slider bearSlider;

    void Start() {
        currentBearVolText = GetComponent<TextMeshProUGUI> ();
        bearVol = CharacterVolume.characterVolume;
        float valToSet = (float)bearVol / 100f;
        bearSlider.value = valToSet;
        currentBearVolText.text = bearVol.ToString() + "/100";
    }

    public void textUpdate(Slider slider)
    {
        bearVol = Mathf.RoundToInt(slider.value * 100);
        currentBearVolText.text = bearVol.ToString() + "/100";
    }
}
