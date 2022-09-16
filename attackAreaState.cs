using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class attackAreaState : StateMachineBehaviour
{
    Agent_AI TeamHaveBall;
    NavMeshAgent agent;
    GameObject WP;
    GameObject[] waypoints; // attack waypoints
    int wpi = 0;    // attack waypoints index
    string lastWP = "start";

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypointsred");
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
        SetNextWaypoint();
    }
    void SetNextWaypoint()
    {
        do
        {
            wpi = Random.Range(0, waypoints.Length - 1);
        }
        while (lastWP.Equals(waypoints[wpi].gameObject.name));

        agent.SetDestination(waypoints[wpi].transform.position);
        lastWP = waypoints[wpi].gameObject.name;
    }
    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == waypoints[wpi].gameObject.name)
        {
            SetNextWaypoint();
        }
    }
}
