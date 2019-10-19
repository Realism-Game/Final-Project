using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSteps : MonoBehaviour
{
	CharacterInputController cc;
	AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
		cc = GetComponent<CharacterInputController>();
        audio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
		if (cc.Velocity > 0f && !audio.isPlaying)
		{
			audio.Play();
		}
	}
}
