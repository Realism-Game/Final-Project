using System.Collections;
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
        if (!myNavMeshAgent.pathPending) {

            if (myNavMeshAgent.remainingDistance == 0) {
                setNextWaypoint();
            } else if (los.foundSomething) {
                if (stateMachine.aiState == AIStateMachine.AIState.Moving && currWaypoint != -1) {
                    myNavMeshAgent.SetDestination(getMovingWaypointDestination());
                }
            }

            if (myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance)
                character.Move(myNavMeshAgent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }
    }

    private Vector3 getMovingWaypointDestination() {
            GameObject g = los.collisionObject;
            Vector3 destination = g.transform.position;
            if (stateMachine.aiState == AIStateMachine.AIState.Moving  && currWaypoint != -1 && g.name == "Bear") {
                //predict position
                VelocityReporter reporter = g.GetComponent<VelocityReporter>();
                float distance = (destination - this.transform.position).magnitude;
                float lookAheadT = Mathf.Clamp(0.0f, distance / myNavMeshAgent.speed, 1.0f);
                Vector3 futureTarget = destination + lookAheadT * reporter.velocity;
                destination = futureTarget;
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
            GameObject g = waypoints[this.currWaypoint];
            Vector3 destination = g.transform.position;
            myNavMeshAgent.SetDestination(destination);
        } catch (System.IndexOutOfRangeException e) {
            Debug.Log(e.Message);
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
            }
        }
    }
}
