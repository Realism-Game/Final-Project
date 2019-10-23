using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BearFootStepEmitter : MonoBehaviour
{
    public void Start()
    {

        InvokeRepeating("ExecuteFootstep", 2.0f, 10.0f);
    }

    private void ExecuteFootstep(){
    	EventManager.TriggerEvent<BearFootStepEvent, Vector3>(transform.position);
    }
}
