using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameEmitter : MonoBehaviour
{
    public void Execute()
    {
        EventManager.TriggerEvent<InGameEvent, Vector3>(new Vector3(0, 0, 0));
    }
}
