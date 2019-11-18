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
    public AudioClip playerDetectionAudio;
    public AudioClip carsAudio;
    public AudioClip spawnAudio;
    public AudioClip gameMenuAudio;
    public AudioClip gameOverAudio;
    public AudioClip[] inGameAudio;
    public AudioClip youWinAudio;
    public AudioClip youLoseAudio;

    private UnityAction<Vector3, int> bearFootStepEventListener;
    private UnityAction<Vector3> guardSoundEventListener;
    private UnityAction<Vector3> inGameListener;
	private UnityAction<Vector3, float> gameMenuListener;
    private UnityAction<Vector3> objectCollisionListener;
    private UnityAction<Vector3> detectionEventListener;
    private UnityAction<Vector3> youWinListener;
    private UnityAction<Vector3> youLoseListener;

    private void Awake()
    {
        bearFootStepEventListener = new UnityAction<Vector3, int>(bearFootstepEventHandler);
        inGameListener = new UnityAction<Vector3>(inGameAudioEventHandler);
		gameMenuListener = new UnityAction<Vector3, float>(gameMenuAudioEventHandler);
        objectCollisionListener = new UnityAction<Vector3>(objectCollisionEventHandler);
        guardSoundEventListener = new UnityAction<Vector3>(guardSoundEventHandler);
        detectionEventListener = new UnityAction<Vector3>(detectionEventHandler);
        youWinListener = new UnityAction<Vector3>(youWinEventHandler);
        youLoseListener = new UnityAction<Vector3>(youLoseEventHandler);
    }

    private void OnEnable()
    {
        EventManager.StartListening<BearFootStepEvent, Vector3, int>(bearFootStepEventListener);
        EventManager.StartListening<InGameEvent, Vector3>(inGameListener);
        EventManager.StartListening<GameMenuEvent, Vector3, float>(gameMenuListener);
        EventManager.StartListening<OnCollisionEvent, Vector3>(objectCollisionListener);
        EventManager.StartListening<GuardSoundEvent, Vector3>(guardSoundEventListener);
        EventManager.StartListening<DetectionEvent, Vector3>(detectionEventListener);
        EventManager.StartListening<YouWinEvent, Vector3>(youWinEventHandler);
        EventManager.StartListening<YouLoseEvent, Vector3>(youLoseEventHandler);
    }

    private void OnDisable()
    {
        EventManager.StopListening<BearFootStepEvent, Vector3, int>(bearFootStepEventListener);
        EventManager.StopListening<InGameEvent, Vector3>(inGameListener);
        EventManager.StopListening<GameMenuEvent, Vector3, float>(gameMenuListener);
        EventManager.StopListening<OnCollisionEvent, Vector3>(objectCollisionListener);
        EventManager.StopListening<GuardSoundEvent, Vector3>(guardSoundEventListener);
        EventManager.StopListening<DetectionEvent, Vector3>(detectionEventListener);
        EventManager.StopListening<YouWinEvent, Vector3>(youWinEventHandler);
        EventManager.StopListening<YouLoseEvent, Vector3>(youLoseEventHandler);
    }

    private void youWinEventHandler(Vector3 pos) {
        if (eventSound3DPrefab)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);
            snd.audioSrc.clip = this.youWinAudio;
            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;
            snd.audioSrc.loop = true;
            snd.audioSrc.Play();
        }
    }

    private void youLoseEventHandler(Vector3 pos) {
        if (eventSound3DPrefab)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);
            snd.audioSrc.clip = this.youLoseAudio;
            snd.audioSrc.minDistance = 5f;
            snd.audioSrc.maxDistance = 100f;
            snd.audioSrc.loop = true;
            snd.audioSrc.Play();
        }
    }

    private void detectionEventHandler(Vector3 pos) {
        if (eventSound3DPrefab)
        {
            EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);
            snd.audioSrc.clip = this.playerDetectionAudio;
            snd.audioSrc.time = 0f;
            snd.audioSrc.Play();
            snd.audioSrc.SetScheduledEndTime(AudioSettings.dspTime+(2f - 0f));
        }
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

	private void gameMenuAudioEventHandler(Vector3 pos, float menuVolume)
	{
		if (eventSound3DPrefab)
		{
			EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);
			snd.audioSrc.clip = this.gameMenuAudio;
			snd.audioSrc.minDistance = 5f;
			snd.audioSrc.maxDistance = 100f;
			snd.audioSrc.loop = true; // Let the scene always play music
			snd.audioSrc.Play();
            snd.audioSrc.volume = menuVolume;
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
