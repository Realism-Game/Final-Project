using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuScriptSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.TriggerEvent<GameMenuEvent, Vector3>(new Vector3(0, 0, 0));
    }
}
