using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
    	if (c.gameObject.name == "Bear")
    	{
    		SceneManager.LoadScene("MenuScene");
    	}
    }
}
