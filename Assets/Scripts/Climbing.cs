using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Climbing : MonoBehaviour
{

    private bool canClimb;
    private Rigidbody rb;
    private RigidbodyFirstPersonController cc;
    public float thrust = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canClimb && rb.isKinematic) {
            Debug.Log("during climb");
            if (Input.GetKey(KeyCode.W)){
                Debug.Log("up");
                transform.position += Vector3.up * Time.deltaTime * thrust;
            }

            if (Input.GetKey(KeyCode.A)){
                transform.position += Vector3.left * Time.deltaTime * thrust;
            }

            if (Input.GetKey(KeyCode.S)){
                transform.position += Vector3.down * Time.deltaTime * thrust;
            }
         
            if (Input.GetKey(KeyCode.D)){
                transform.position += Vector3.right * Time.deltaTime * thrust;
            }
        }
        if (canClimb && Input.GetKeyDown(KeyCode.E)) {
            //cc.enabled = false;
            rb.isKinematic = true;
            rb.useGravity = false;
            //StartCoroutine(afterClimb());
            Debug.Log("before climb");
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionZ;
        }
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }


    IEnumerator afterClimb() {
        yield return new WaitForSeconds(0.25f);
        Debug.Log("after climb");
        //cc.enabled = true;
        rb.isKinematic = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Climb") {
            canClimb = true;
            
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Climb") {
            Debug.Log("after climb");
            canClimb = false;
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }
    }
}
