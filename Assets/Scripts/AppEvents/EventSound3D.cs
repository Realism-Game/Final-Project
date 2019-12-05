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
                int menuBearVol = CharacterVolume.characterVolume;
                int finalBearVol = InGameCharVol.bearVol;

                int bearVol = (finalBearVol == 0) ? menuBearVol : finalBearVol;
                setVolume(((float) bearVol / 100.0f));
                break;
            case "DetectionSound":
                break;
            default:
                int menuVol = BgVolume.backgroundVolume;
                int finalVol = InGameVolume.inGameVol;
                int mainVol = (finalVol == 0) ? menuVol : finalVol;
                setVolume(((float) mainVol / 100.0f));
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
