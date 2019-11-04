using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public EventSound3D eventSound3DPrefab;
    public AudioClip objectFallToGroundAudio;
    public AudioClip[] bearFootStepAudio;
    public AudioClip[] guardAudio;
    public AudioClip objectCollisionAudio;
    public AudioClip keysChainAudio;
    public AudioClip playerDetectionAudio;
    public AudioClip carsAudio;
    public AudioClip spawnAudio;
    public AudioClip gameMenuAudio;
    public AudioClip gameOverAudio;
    public AudioClip[] inGameAudio;

    private UnityAction<Vector3, int> bearFootStepEventListener;
    private UnityAction<Vector3> guardSoundEventListener;
    private UnityAction<Vector3> inGameListener;
	private UnityAction<Vector3> gameMenuListener;
    private UnityAction<Vector3> objectCollisionListener;

    private void Awake()
    {
        bearFootStepEventListener = new UnityAction<Vector3, int>(bearFootstepEventHandler);
        inGameListener = new UnityAction<Vector3>(inGameAudioEventHandler);
		gameMenuListener = new UnityAction<Vector3>(gameMenuAudioEventHandler);
        objectCollisionListener = new UnityAction<Vector3>(objectCollisionEventHandler);
        guardSoundEventListener = new UnityAction<Vector3>(guardSoundEventHandler);
    }

    private void OnEnable()
    {
        EventManager.StartListening<BearFootStepEvent, Vector3, int>(bearFootStepEventListener);
        EventManager.StartListening<InGameEvent, Vector3>(inGameListener);
        EventManager.StartListening<GameMenuEvent, Vector3>(gameMenuListener);
        EventManager.StartListening<OnCollisionEvent, Vector3>(objectCollisionListener);
        EventManager.StartListening<OnCollisionEvent, Vector3>(guardSoundEventListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening<BearFootStepEvent, Vector3, int>(bearFootStepEventListener);
        EventManager.StopListening<InGameEvent, Vector3>(inGameListener);
        EventManager.StopListening<GameMenuEvent, Vector3>(gameMenuListener);
        EventManager.StopListening<OnCollisionEvent, Vector3>(objectCollisionListener);
        EventManager.StopListening<OnCollisionEvent, Vector3>(guardSoundEventListener);
    }



    private void bearFootstepEventHandler(Vector3 pos, int characterVol)
    {

        if (spawnAudio)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);

            snd.audioSrc.clip = this.bearFootStepAudio[0];

            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;
            snd.audioSrc.volume = (float) characterVol;

            snd.audioSrc.Play();
        }
    }

    private void guardSoundEventHandler(Vector3 pos)
    {

        if (spawnAudio)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);

            snd.audioSrc.clip = this.guardAudio[0];

            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;

            snd.audioSrc.Play();
        }
    }

    private void inGameAudioEventHandler(Vector3 pos)
    {
        if (eventSound3DPrefab)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);
            snd.audioSrc.clip = this.inGameAudio[0];
            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;
            snd.audioSrc.loop = true; // Let the scene always play music
            snd.audioSrc.Play();
        }
    }

	private void gameMenuAudioEventHandler(Vector3 pos)
	{
		if (eventSound3DPrefab)
		{
			EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);
			snd.audioSrc.clip = this.gameMenuAudio;
			snd.audioSrc.minDistance = 5f;
			snd.audioSrc.maxDistance = 100f;
			snd.audioSrc.loop = true; // Let the scene always play music
			snd.audioSrc.Play();
		}
	}

    private void objectCollisionEventHandler(Vector3 pos)
    {
        if (eventSound3DPrefab)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);
            snd.audioSrc.clip = this.objectCollisionAudio;
            snd.audioSrc.Play();
        }
    }
}
