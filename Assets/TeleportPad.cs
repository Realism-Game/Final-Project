using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour
{
    public GameObject ui;
    public GameObject objToTP;
    public GameObject tpLoc;

    void Start()
    {
    	ui.SetActive(false);
	}

	void OnTriggerStay(Collider other)
	{
		ui.SetActive(true);
		if((other.gameObject.tag == "Detectable") && Input.GetKeyDown(KeyCode.E))
		{
			objToTP.transform.position = tpLoc.transform.position;
		}
	}

	void OnTriggerExit()
	{
		ui.SetActive(false);
	}
	
}
