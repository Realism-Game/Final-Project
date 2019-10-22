using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BearFootStepEmitter : MonoBehaviour
{
    public void ExecuteFootstep()
    {

        EventManager.TriggerEvent<BearFootStepEvent, Vector3>(transform.position);
    }
}
