using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameCamera : MonoBehaviour
{
    TextMeshProUGUI inGameCam;
    public Slider cameraSlider;
    public static int camRate = 0;

    void Start() {
        inGameCam = GetComponent<TextMeshProUGUI> ();
        camRate = CameraTurnRate.cameraRate;
        float valToSet = (float)camRate / 10f;
        cameraSlider.value = valToSet; // Set value for slider
        inGameCam.text = (camRate/10).ToString() + "/10";
    }

    public void textUpdate(Slider slider)
    {
        camRate = Mathf.RoundToInt(slider.value * 100);
        inGameCam.text = (camRate/10).ToString() + "/10";
    }
}
