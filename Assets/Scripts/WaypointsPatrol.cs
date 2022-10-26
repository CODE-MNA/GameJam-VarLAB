using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaypointsPatrol : MonoBehaviour
{
    [SerializeField]
    List<Vector3> waypointList;

    [SerializeField]
    float secondsBetweenPoints;

    float cooldownTimer;

    

    Vector3 nextPos;

    [SerializeField]
    private float speed;

    int currentWaypointIndex;
    private float turnSpeed = 4f;

    void Start()
    {
        InitializePatrolling();
    }


    //TO CONTROL WHERE ENEMY GOES JUST ADD WAYPOINTS FROM PREFAB FOLDER AS CHILDREN TO THE
    //ENEMY GAME OBJECT


    private void InitializePatrolling()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Waypoint"))
            {
                waypointList.Add(child.position);

                child.gameObject.SetActive(false);
            }
        }

        currentWaypointIndex = 0;

     
    }

    void Update()
    {
        if (waypointList == null) return;
        if(waypointList.Count == 0) return;
        //If cooldown is 0, move a bit towards position
        //if reached position reset increase cooldown and switch next waypoint
        if (WaypointReached(waypointList[currentWaypointIndex]))
        {
            cooldownTimer = secondsBetweenPoints;
            currentWaypointIndex = GetNextWaypoint(currentWaypointIndex);


        }


        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            RotateTowardsWaypoint(waypointList[currentWaypointIndex]);


        }
        else
        {
            cooldownTimer = 0;
            MoveStepTowardsWaypoint(waypointList[currentWaypointIndex]);
        }
        
        

    }

    void MoveStepTowardsWaypoint(Vector3 waypoint)
    {
     
        
        nextPos = Vector3.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);

        transform.position = nextPos;   
    }


    void RotateTowardsWaypoint(Vector3 waypoint)
    {
        Vector3 directionToWaypoint = (waypoint - transform.position);


        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(directionToWaypoint),turnSpeed * Time.deltaTime);
    }

    bool WaypointReached(Vector3 waypoint)
    {
        return waypoint == transform.position;
    }


    int GetNextWaypoint(int currentWaypoint)
    {
        if(currentWaypoint == waypointList.Count - 1)
        {
            waypointList.Reverse();
            return 0;
        }
        return currentWaypoint + 1;
    }
}
