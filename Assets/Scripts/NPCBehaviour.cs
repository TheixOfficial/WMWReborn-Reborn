using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour {

    Vector3 targetVector;

    [SerializeField]
    List<Waypoint> waypoints;
    //Transform destination;

    NavMeshAgent navMeshAgent;

    public float dist;
    public int currentWaypointIndex;
    bool moveForward;

    // Use this for initialization
    void Start ()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            if (waypoints != null && waypoints.Count >= 2)
            {
                currentWaypointIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient waypoints for basic patrolling behaviour");
            }
        }
	}

    public void Update()
    {
        dist = Vector3.Distance(targetVector, transform.position);

        changeWaypoint();
        SetDestination();
    }

    private void SetDestination()
    {
        if (waypoints != null)
        {
            targetVector = waypoints[currentWaypointIndex].transform.position;
            navMeshAgent.SetDestination(targetVector);
        }

        /*if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }*/
    }

    private void changeWaypoint()
    {
        if (dist <= 0.6f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }
}
