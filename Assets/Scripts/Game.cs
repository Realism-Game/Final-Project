﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public CharacterInputController deer, bird, rabbit;
    public GameObject firstDoor, secondDoor, thirdDoor, enemy;
    public Trigger triggerA1, triggerA2, triggerA3, triggerB;
    public CanvasGroup canvasGroup;

    public void GameOver()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha =  1f;
        Time.timeScale = 0f;
    }

    void Start()
    {
        EventManager.TriggerEvent<InGameEvent, Vector3>(new Vector3(0, 0, 0));
    }

    void Update()
    {
        if (triggerA1.IsSet && triggerA2.IsSet && triggerA3.IsSet)
        {
            Destroy(firstDoor);
        }
        if (triggerB.IsSet)
        {
            Destroy(thirdDoor);
        }
        if (enemy == null)
        {
            Destroy(secondDoor);
        }

        if (Input.GetKeyUp(KeyCode.R) || deer == null || rabbit == null || bird == null)
        {
            GameOver();
        } else if (InEndZone(bird) && InEndZone(deer) && InEndZone(rabbit))
        {
            GameOver();
        }
    }

    bool InEndZone(CharacterInputController character)
    {
        float x = character.transform.position.x;
        float z = character.transform.position.z;
        if (x > 0f && x < 50f && z < 0f && z > -50f)
        {
            return true;
        }
        return false;
    }
}
