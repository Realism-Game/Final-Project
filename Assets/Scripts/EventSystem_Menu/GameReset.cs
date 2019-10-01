using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    // Main func to route the sence to the main game
    public void startGame()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
