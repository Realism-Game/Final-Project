using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableKey: MonoBehaviour{
    
    public float rotateSpeed = 75f;
    public float duration = 5.0f;
    //public float rotateSpeed = 75f;
    public GameObject bars;
    private int respawnTimer = 0;
    private Animator a;
    private Vector3 start;
    private Renderer r;


    void Start() {
        r = this.transform.GetChild(0).GetComponent<Renderer>();
        start = this.transform.position;
    }

    void Update() {
        if (r.enabled == true) {
            transform.Rotate(Vector3.up * rotateSpeed *  Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider c) {
        if(c.attachedRigidbody != null && c.gameObject.CompareTag("Detectable")) {
            GameObject parent = c.attachedRigidbody.gameObject;
            Collector collector = parent.GetComponent<Collector>();
            PlayerController pc = parent.GetComponent<PlayerController>();
            if (collector != null) {
                //Destroy(this.gameObject);
                Debug.Log("pick up key");
                r.enabled = false;
                collector.ReceiveKey();
                StartCoroutine(afterCollectingKey());
                // this.transform.GetComponent<AudioSource>().Play(0);
            }

        }
    }

    IEnumerator afterCollectingKey() {
        Debug.Log("after climb");
        float elapsedTime = 0f;
        while (elapsedTime < duration) {
         bars.transform.Translate(Vector3.down * Time.deltaTime);
         elapsedTime += Time.deltaTime;
         yield return null;
        }
    }
}
