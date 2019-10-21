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

    private UnityAction<Vector3> rabbitFootStepEventListener;
    private UnityAction<Vector3> bearFootStepEventListener;
    private UnityAction<Vector3> monkeyFootStepEventListener;
    private UnityAction<Vector3> guardSoundEventListener;

    private void Awake()
    {
        rabbitFootStepEventListener = new UnityAction<Vector3>(rabbitFootstepEventHandler);
    }

    private void OnEnable()
    {
        EventManager.StartListening<RabbitFootStepEvent, Vector3>(rabbitFootStepEventListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening<RabbitFootStepEvent, Vector3>(rabbitFootStepEventListener);
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
}
