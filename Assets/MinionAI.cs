using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MinionAI : MonoBehaviour
{
	public Animator anim;
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
	public GameObject[] waypoints;
	int currWaypoint = -1;
	//VelocityReporter velocity;
	Vector3 waypointVelocity;
	Vector3 agentVelocity;
	Vector3 predictVector;
	
	public enum AIState
	{
		Patrol,
		MovingWaypoint
	};

	public AIState aiState;
	
    void Start()
    {
    	aiState = AIState.Patrol;
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
		
        setNextWayPoint();
        setDestination();

        
    }

    void Update()
    {
        // Update destination if the target moves one unit
        if (currWaypoint == 1){
			aiState = AIState.MovingWaypoint;
			agent.speed = 10;
        }
        else {
			aiState = AIState.Patrol;
			agent.speed = 10;
        }

        switch (aiState){
			case AIState.Patrol:
				if (!agent.pathPending && agent.remainingDistance < 0.5f){
				    setNextWayPoint();}
				setDestination();
				anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);
				break;
				
			case AIState.MovingWaypoint:
				if (!agent.pathPending && agent.remainingDistance < 0.5f){
				    setNextWayPoint();
			    }
				setDestination();
				anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);
				break;
        }
    }

    void setNextWayPoint()
    {
    	if (waypoints.Length == 0)
            return;
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
    }

    void setDestination()
    {
    	agent.destination = waypoints[currWaypoint].transform.position;
    	//if (currWaypoint == 1){
    		//waypointVelocity = waypoints[5].GetComponent<VelocityReporter>().velocity;
        	//agentVelocity = agent.GetComponent<VelocityReporter>().velocity;
        	//predictVector = agentVelocity + waypointVelocity;
    		//agent.destination = (agent.transform.position + predictVector);
    	//}
    }
}
