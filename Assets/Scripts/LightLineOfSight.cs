using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightLineOfSight: MonoBehaviour{
    public bool foundSomething;
    public GameObject collisionObject;
    private Collider collider;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider c) {
        if(c.gameObject.CompareTag("Detectable")) {
            GameObject gameObject = c.gameObject;
            if (gameObject != null) {
                foundSomething = true;
                collisionObject = gameObject;
                collider.enabled = false;
            }
        }
    }

    void OnTriggerExit(Collider c) {
        if (c.gameObject.CompareTag("Detectable")) {
            foundSomething = false;
        }
    }
}