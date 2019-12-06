using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BearFootStepEmitter : MonoBehaviour
{
    public void Start()
    {
        InvokeRepeating("ExecuteFootstep", 2.0f, 13.0f); // Executing every 13s
    }

    private void ExecuteFootstep() {
        EventManager.TriggerEvent<BearFootStepEvent, Vector3>(transform.position);
    }
}
