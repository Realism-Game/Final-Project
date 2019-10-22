using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyFootStepEmitter : MonoBehaviour
{
    public void ExecuteFootstep()
    {

        EventManager.TriggerEvent<MonkeyFootStepEvent, Vector3>(transform.position);
    }
}
