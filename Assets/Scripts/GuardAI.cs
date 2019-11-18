﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof (ThirdPersonCharacter))]
public class GuardAI : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject GameController;
    public int currWaypoint = -1;
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent myNavMeshAgent;
    private AIStateMachine stateMachine;
    private float previousYRotate;
    private int stationary;
    private ThirdPersonCharacter character;
    private LightLineOfSight los;
    private Vector3 lastSeen;
    private GameController game;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<AIStateMachine>();
        los = GetComponentInChildren<LightLineOfSight>();
        anim = GetComponent<Animator>();
        myNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        game = GameController.GetComponent<GameController>();
        setNextWaypoint();
        previousYRotate = this.transform.eulerAngles.y;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P)){
            Debug.Log("velocity: " + myNavMeshAgent.velocity);
            Debug.Log("acceleration: " + myNavMeshAgent.acceleration);
            Debug.Log("speed: " + myNavMeshAgent.speed);
        }
        //anim.SetFloat("Forward", myNavMeshAgent.velocity.magnitude / myNavMeshAgent.speed);
        if (!myNavMeshAgent.pathPending) {

            if (myNavMeshAgent.remainingDistance == 0) {
                setNextWaypoint();
            } else if (stateMachine.aiState == AIStateMachine.AIState.Moving) {
                if ((myNavMeshAgent.remainingDistance - myNavMeshAgent.stoppingDistance) >= 0.25f && los.collisionObject != null) {
                    Vector3 destination = getMovingWaypointDestination();
                    myNavMeshAgent.SetDestination(destination);
                }
            } else if (stateMachine.aiState == AIStateMachine.AIState.LostQuarry && lastSeen != new Vector3(-100f, -100f, -100f)) {
                //Debug.Log("Last Seen: " + lastSeen);
                myNavMeshAgent.SetDestination(lastSeen);
                lastSeen = new Vector3(-100f, -100f, -100f);
            }
            if (myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance)
                character.Move(myNavMeshAgent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }
    }

    private Vector3 getMovingWaypointDestination() {
            //Debug.Log(myNavMeshAgent.remainingDistance - myNavMeshAgent.stoppingDistance);
            GameObject g = los.collisionObject;
            Vector3 destination = g.transform.position;
            lastSeen = destination;
            //Debug.Log("waypoint "+destination);
            if (stateMachine.aiState == AIStateMachine.AIState.Moving  && currWaypoint != 0) {
                //predict position
                VelocityReporter reporter = g.GetComponent<VelocityReporter>();
                /**
                dist = (target.pos - agent.pos).Length()

                lookAheadT = Dist/agent.maxSpeed

                futureTarget = target.pos + lookAheadT  * target.velocity
                **/
                float distance = (destination - this.transform.position).magnitude;
                float lookAheadT = Mathf.Clamp(0.0f, distance / myNavMeshAgent.speed, 3.0f);
                Vector3 futureTarget = destination + lookAheadT * reporter.velocity;
                destination = futureTarget;
                /**
                Debug.Log("distance "+distance);
                Debug.Log("lookAheadT " + lookAheadT);
                Debug.Log("minion speed "+myNavMeshAgent.speed);
                Debug.Log("waypoint speed "+reporter.velocity.magnitude);
                Debug.Log("waypoint velocity "+reporter.velocity);
                Debug.Log("waypoint rawvelocity "+reporter.rawVelocity);
                **/
                //Debug.Log("futureTarget "+futureTarget);
            }
            
            return destination;
    }

    private void setNextWaypoint() {
        try {

            if (waypoints == null || waypoints.Length == 0) {
                throw new System.IndexOutOfRangeException();
            }

            if (this.currWaypoint >= (waypoints.Length - 1)) {
                this.currWaypoint = 0;
            } else {
                this.currWaypoint++;
            }
            //Debug.Log(currWaypoint);
            GameObject g = waypoints[this.currWaypoint];
            Vector3 destination = g.transform.position;
            //Debug.Log("waypoint "+destination);
            if (stateMachine.aiState == AIStateMachine.AIState.Moving && currWaypoint != 0) {
                destination = getMovingWaypointDestination();
            }
            if (los.foundSomething) {
                destination = los.collisionObject.transform.position;
            }
            //Debug.Log("setting next");
            myNavMeshAgent.SetDestination(destination);
        } catch (System.IndexOutOfRangeException e) {
            Debug.Log(e.Message);
            // Set IndexOutOfRangeException to the new exception's InnerException.
            //throw new System.ArgumentOutOfRangeException("index parameter is out of range.", e);
        } catch (System.ArgumentOutOfRangeException e) {
            Debug.Log(e.Message);
        }
    }

    void OnCollisionEnter(Collision c) {
        if(c.gameObject.CompareTag("Detectable")) {
            GameObject gameObject = c.gameObject;
            los.foundSomething = false;
            Collider collider = gameObject.GetComponent<Collider>();
            collider.enabled = true;
            if (gameObject.name == "Bear") {
                game.GameOver = true;
                // EventManager.TriggerEvent<YouLoseEvent, Vector3>(new Vector3(0, 0, 0));
            }
        }
    }
}
