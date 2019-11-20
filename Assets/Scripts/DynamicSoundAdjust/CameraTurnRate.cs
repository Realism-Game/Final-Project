using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraTurnRate : MonoBehaviour
{
    TextMeshProUGUI currentCameraTurnRate;
    public static int cameraRate = 100;

    void Start() {
        currentCameraTurnRate = GetComponent<TextMeshProUGUI> ();
        currentCameraTurnRate.text = cameraRate.ToString() + "/100";
    }

    public void textUpdate(float value)
    {
        cameraRate = Mathf.RoundToInt(value * 100);
        currentCameraTurnRate.text = cameraRate.ToString() + "/100";
    }
}
