using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{

    public EventSound3D eventSound3DPrefab;
    public AudioClip objectFallToGroundAudio;
    public AudioClip[] rabbitFootStepAudio;
    public AudioClip[] bearFootStepAudio;
    public AudioClip[] monkeyFootStepAudio;
    public AudioClip[] guardAudio;
    public AudioClip objectCollisionAudio;
    public AudioClip keysChainAudio;
    public AudioClip playerDetectionAudio;
    public AudioClip carsAudio;
    public AudioClip spawnAudio;
    public AudioClip gameMenuAudio;
    public AudioClip gameOverAudio;
    public AudioClip[] inGameAudio;

    private UnityAction<Vector3> rabbitFootStepEventListener;
    private UnityAction<Vector3> bearFootStepEventListener;
    private UnityAction<Vector3> monkeyFootStepEventListener;
    private UnityAction<Vector3> guardSoundEventListener;
    private UnityAction<Vector3> inGameListener;
	private UnityAction<Vector3> gameMenuListener;

    private void Awake()
    {
        rabbitFootStepEventListener = new UnityAction<Vector3>(rabbitFootstepEventHandler);
        bearFootStepEventListener = new UnityAction<Vector3>(bearFootstepEventHandler);
        monkeyFootStepEventListener = new UnityAction<Vector3>(monkeyFootstepEventHandler);
        inGameListener = new UnityAction<Vector3>(inGameAudioEventHandler);
		gameMenuListener = new UnityAction<Vector3>(gameMenuAudioEventHandler);
    }

    private void OnEnable()
    {
        EventManager.StartListening<RabbitFootStepEvent, Vector3>(rabbitFootStepEventListener);
        EventManager.StartListening<BearFootStepEvent, Vector3>(bearFootStepEventListener);
        EventManager.StartListening<MonkeyFootStepEvent, Vector3>(monkeyFootStepEventListener);
        EventManager.StartListening<InGameEvent, Vector3>(inGameListener);
        EventManager.StartListening<GameMenuEvent, Vector3>(gameMenuListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening<RabbitFootStepEvent, Vector3>(rabbitFootStepEventListener);
        EventManager.StopListening<BearFootStepEvent, Vector3>(bearFootStepEventListener);
        EventManager.StopListening<MonkeyFootStepEvent, Vector3>(monkeyFootStepEventListener);
        EventManager.StopListening<InGameEvent, Vector3>(inGameListener);
        EventManager.StopListening<GameMenuEvent, Vector3>(gameMenuListener);
    }


    private void rabbitFootstepEventHandler(Vector3 pos)
    {

        if (spawnAudio)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);

            snd.audioSrc.clip = this.rabbitFootStepAudio[Random.Range(0, rabbitFootStepAudio.Length)];

            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;

            snd.audioSrc.Play();
        }
    }

    private void bearFootstepEventHandler(Vector3 pos)
    {

        if (spawnAudio)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);

            snd.audioSrc.clip = this.bearFootStepAudio[0];

            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;

            snd.audioSrc.Play();
        }
    }

    private void monkeyFootstepEventHandler(Vector3 pos)
    {

        if (spawnAudio)
        {

            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);

            snd.audioSrc.clip = this.monkeyFootStepAudio[0];

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
}
