using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EventSound3D : MonoBehaviour
{
    public AudioSource audioSrc;
    private float musicVolume = 1.0f; // Default sound

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void setVolume(float vol) {
        musicVolume = vol;
    }

    void Update()
    {
        if (!audioSrc.isPlaying)
        {
            Destroy(this.gameObject);
        }

        // Switch checking audio sound volume
        switch (audioSrc.clip.name.ToString())
        {
            case "grizzlybear":
                setVolume(((float) CharacterVolume.characterVolume / 100.0f));
                break;
            case "Detection":
                if (!LightLineOfSight.isPlaying)
                    audioSrc.Stop();
                break;
            default:
                setVolume(((float) BgVolume.backgroundVolume / 100.0f));
                break;
        }

        audioSrc.volume = musicVolume;
    }
}
