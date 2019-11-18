using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraTurnRate : MonoBehaviour
{
    TextMeshProUGUI currentCameraTurnRate;
    public int cameraRate;

    void Start() {
        currentCameraTurnRate = GetComponent<TextMeshProUGUI> ();
        cameraRate = 100; // Set default value when start game
        currentCameraTurnRate.text = cameraRate.ToString() + "/100";
    }

    public void textUpdate(float value)
    {
        cameraRate = Mathf.RoundToInt(value * 100);
        currentCameraTurnRate.text = cameraRate.ToString() + "/100";
    }
}
