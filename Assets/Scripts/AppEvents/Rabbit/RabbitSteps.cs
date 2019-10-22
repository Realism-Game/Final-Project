using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSteps : MonoBehaviour
{
	CharacterInputController cc;
    Vector3 lastPostion;

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
		cc = GetComponent<CharacterInputController>();
	}

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(lastPostion, transform.position) > 4f)
        {
            setTargetTalk();
            if (cc != null && cc.enabled)
                EventManager.TriggerEvent<RabbitFootStepEvent, Vector3>(transform.position);
        }
    }
}
