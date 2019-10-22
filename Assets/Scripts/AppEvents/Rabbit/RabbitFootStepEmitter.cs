using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RabbitFootStepEmitter : MonoBehaviour
{
    public void ExecuteFootstep()
    {

        EventManager.TriggerEvent<RabbitFootStepEvent, Vector3>(transform.position);
    }
}
