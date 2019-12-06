using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public bool GameOver = false;
    public GameObject gameOver;
	private GameOver gameover;
    public GameObject GUI;

    void Start() {
        EventManager.TriggerEvent<InGameEvent, Vector3>(new Vector3(0, 0, 0));
        if (!GameInstruction.firstTime) {
            GUI.SetActive(true);
        }
    }

    // Update is called once per frame
    void Awake()
    {
        gameover = gameOver.GetComponent<GameOver>();
    }

    void Update()
    {
        if (!GameInstruction.firstTime) {
            GameInstruction.viewOn = false;
        } else {
            GameInstruction.viewOn = true;
        }

        if (GameOver)
        {
            gameover.gameOver = true;
        }
    }
}
