using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public bool GameOver = false;
    public GameObject gameOver;
	private GameOver gameover;
    // Update is called once per frame
    void Awake()
    {
        gameover = gameOver.GetComponent<GameOver>();
    }

    void Update()
    {
        if (GameOver)
        {
            gameover.gameOver = true;
        }
    }
}
