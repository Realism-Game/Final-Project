using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour {

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public bool lostQuarry = false;

    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public Transform visibleTarget;

    private Collider collider;

    void Start() {
        //StartCoroutine ("FindTargetsWithDelay", .2f);
        collider = GetComponent<Collider>();
    }

    void FixedUpdate() {
        //FindVisibleTargets();
        FindVisibleTarget();
    }


    IEnumerator FindTargetsWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds (delay);
            FindVisibleTargets ();
        }
    }

    void FindVisibleTargets() {
        visibleTargets.Clear ();
        Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++) {
            Transform target = targetsInViewRadius [i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2) {
                float dstToTarget = Vector3.Distance (transform.position, target.position);
                if (!Physics.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)) {
                    visibleTargets.Add(target);
                }
            }
        }
    }

    void FindVisibleTarget() {

        Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);
        if (targetsInViewRadius.Length == 1 && transform.position.y > 0) {
            Transform target = targetsInViewRadius [0].transform;
            if (!target.GetComponent<PlayerController>().hidden) {

                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2) {
                    //Debug.Log("before" + transform.position);
                    float dstToTarget = Vector3.Distance (transform.position, target.position);
                    if (!Physics.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask)) {
                        visibleTarget = target;
                        lostQuarry = false;
                        //Debug.Log("after" + transform.position);
                        //Debug.DrawRay(transform.position, dirToTarget * dstToTarget, Color.green, 3f);
                        //Debug.Log("Target Acquired");
                    } else {
                        if (visibleTarget) {
                            visibleTarget = null;
                            lostQuarry = true;
                            Debug.Log("Target Blocked");
                        }
                    }
                } else {
                    if (visibleTarget) {
                        visibleTarget = null;
                        lostQuarry = true;
                        Debug.Log("Target outside of angle");
                    }                
                }
            }
        } else if (transform.position.y > 0) {
            if (visibleTarget) {
                visibleTarget = null;
                lostQuarry = true;
                Debug.Log("Target Lost");
            }
        }
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
        if (!angleIsGlobal) {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}