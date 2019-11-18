using UnityEngine;
using System.Collections;

public class GameMenuEmitter : MonoBehaviour
{
    public void Execute()
    {
        EventManager.TriggerEvent<GameMenuEvent, Vector3>(new Vector3(0, 0, 0));
    }
}
