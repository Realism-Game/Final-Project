using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraTurnRate : MonoBehaviour
{
    TextMeshProUGUI currentCameraTurnRate;
    public static int cameraRate = 3; // Default camera rate turn
    public Slider cameraSlider;

    void Start() {
        currentCameraTurnRate = GetComponent<TextMeshProUGUI> ();
        float valToSet = (float)cameraRate / 10f;
        cameraSlider.value = valToSet;
        currentCameraTurnRate.text = (cameraRate/10).ToString() + "/10";
    }

    public void textUpdate(Slider slider)
    {
        cameraRate = Mathf.RoundToInt(slider.value * 100);
        currentCameraTurnRate.text = (cameraRate/10).ToString() + "/10";
    }
}
