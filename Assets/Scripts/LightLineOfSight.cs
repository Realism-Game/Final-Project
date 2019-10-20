using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightLineOfSight: MonoBehaviour{
    public bool foundSomething;
    public Vector3 location;

    void OnTriggerEnter(Collider c) {
        if(c.attachedRigidbody != null && c.gameObject.CompareTag("Detectable")) {
            GameObject gameObject = c.gameObject;
            if (gameObject != null) {
                Debug.Log("collision");
                foundSomething = true;
                location = gameObject.transform.position;
                Destroy(gameObject);
                StartCoroutine(afterTrigger());
            }
        }
    }

    IEnumerator afterTrigger() {
        yield return new WaitForSeconds(.01f);
        foundSomething = false;
        
    }

    void OnTriggerExit(Collider c) {
        foundSomething = false;
        //StartCoroutine(afterTrigger());
    }
}