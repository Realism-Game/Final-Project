using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EventSound3D : MonoBehaviour
{
    public AudioSource audioSrc;
    private float musicVolume = 1.0f; // Default sound
    private bool menuSoundPlaying = false;

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
            case "DetectionSound":
                // if (LightLineOfSight.maybeLost)
                //     Destroy(this.gameObject);
                break;
            default:
                setVolume(((float) BgVolume.backgroundVolume / 100.0f));
                // If game over occur then stop, and destroy background music
                // if (gameover.gameOver && !menuSoundPlaying) {
                //     audioSrc.Stop();
                //     Destroy(this.gameObject);
                //     EventManager.TriggerEvent<YouLoseEvent, Vector3>(new Vector3(0, 0, 0));
                //     menuSoundPlaying = true;
                // }
                break;
        }
        audioSrc.volume = musicVolume;
    }
}
