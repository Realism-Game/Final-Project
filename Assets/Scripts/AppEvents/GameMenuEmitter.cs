using UnityEngine;
using System.Collections;

public class GameMenuEmitter : MonoBehaviour
{
    public void Execute()
    {
        EventManager.TriggerEvent<GameMenuEvent, Vector3, float>(new Vector3(0, 0, 0), 0.0f);
    }
}
