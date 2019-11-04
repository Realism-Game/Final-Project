using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
	private GameWin gamewin;
	public GameObject gameWin;

	void Awake()
    {
        gamewin = gameWin.GetComponent<GameWin>();
    }

    void OnTriggerEnter(Collider c)
    {
    	if (c.gameObject.name == "Bear")
    	{
			gamewin.gameWin = true;
    	}
    }
}
