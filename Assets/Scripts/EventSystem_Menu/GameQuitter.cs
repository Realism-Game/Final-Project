using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    // Main func to quit the application
    public void quitGame()
    {
        Debug.Log("GAME QUIT");
        Application.Quit();
    }
}
