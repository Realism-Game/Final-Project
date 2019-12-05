using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableMeat: MonoBehaviour{
    
    public int timeTillRespawn = 1200;
    public float rotateSpeed = 75f;
    private int respawnTimer = 0;
    private Animator a;
    private Vector3 start;
    private Renderer r;
    private Renderer r1;


    void Start() {
        r = this.transform.GetComponent<Renderer>();
        r1 = this.transform.GetChild(0).GetComponent<Renderer>();
        start = this.transform.position;
    }

    void Update() {
        if (r.enabled == false) {
            if (respawnTimer < timeTillRespawn) {
                respawnTimer++;
            } else if (respawnTimer >= timeTillRespawn) {
                respawnTimer = 0;
                r.enabled = true;
                r1.enabled = true;
                Debug.Log("respawned meat");
            }
        } else {
            transform.Rotate(Vector3.back * rotateSpeed *  Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider c) {
        if(c.attachedRigidbody != null && c.gameObject.CompareTag("Detectable")) {
            GameObject parent = c.attachedRigidbody.gameObject;
            Collector collector = parent.GetComponent<Collector>();
            PlayerController pc = parent.GetComponent<PlayerController>();
            if (collector != null) {
                //Destroy(this.gameObject);
                Debug.Log("pick up meat");
                r.enabled = false;
                r1.enabled = false;
                collector.ReceiveMeat();
                pc.stamina = pc.maxStamina;
                Debug.Log("back at max stamina");
                this.transform.GetComponent<AudioSource>().Play(0);
            }

        }
    }
}
