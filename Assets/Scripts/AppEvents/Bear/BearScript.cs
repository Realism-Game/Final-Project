using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    Bear bear;
    Vector3 lastPostion;
    CharacterVolume characterVol;

    private void setTargetTalk()
    {
        lastPostion = transform.position;
    }


    private void Start()
    {
        lastPostion = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        bear = GetComponent<Bear>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(lastPostion, transform.position) > 8f)
        {
            setTargetTalk();
            if (bear != null && bear.enabled) {
                Debug.Log(characterVol.characterVolume);
                EventManager.TriggerEvent<BearFootStepEvent, Vector3, int>(transform.position, characterVol.characterVolume);
            }
        }
    }

	private void OnCollisionEnter(Collision c)
	{
		EventManager.TriggerEvent<OnCollisionEvent, Vector3>(new Vector3(0, 0, 0)); // Handle collision
	}
}
